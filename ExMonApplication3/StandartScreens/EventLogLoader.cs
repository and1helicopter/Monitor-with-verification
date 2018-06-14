using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.ComponentModel;
using UniSerialPort;

namespace StandartScreens
{
    public class EventLogLoader 
    {
        public delegate void ProcessUpdater(int NowCompleted);
        public ProcessUpdater ProcessUpdate;

        public delegate void LoadingCompleter(bool LoadingOk);
        public LoadingCompleter LoadindComplete;

        BackgroundWorker backgroundWorker;
        AsynchSerialPort serialPort;
        AutoResetEvent waitResponce = new AutoResetEvent(false);

        ushort blockCount;
        ushort startDataAddr;
        ushort loadEventAddr;
        ushort eventCount;
        public ushort EventCount
        {
            get { return eventCount; }
        }

        List<ushort[]> eventData = new List<ushort[]>();
        public List<ushort[]> EventData
        {
            get { return eventData; }
        }

        int eventIndex = 0;
        int blockIndex = 0;
        ushort[] loadEventLine;

        public EventLogLoader(AsynchSerialPort AsynchSerialPort, ushort BlockCount, ushort StartDataAddr, ushort LoadEventAddr, ushort EventCount)
        {
            blockCount = BlockCount;
            startDataAddr = StartDataAddr;
            loadEventAddr = LoadEventAddr;
            eventCount = EventCount;
            serialPort = AsynchSerialPort;
            loadEventLine = new ushort[blockCount * 32];
        }

        public void StartLoading()
        {
            backgroundWorker = new BackgroundWorker();
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.WorkerSupportsCancellation = true;
            backgroundWorker.DoWork += backgroundWorker_DoWork;
            backgroundWorker.ProgressChanged += backgroundWorker_ProgressChanged;
            backgroundWorker.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;
            backgroundWorker.RunWorkerAsync(null);
        }

        private void serialPort_DataReceived(bool DataOk, ushort[] ParamRTU, object param)
        {
            if (!DataOk)
            {
                backgroundWorker.CancelAsync();
            }
            waitResponce.Set();
        }

        private void serialPort_LoadDataReceived(bool DataOk, ushort[] ParamRTU, object param)
        {
            if (DataOk)
            {
                Array.Copy(ParamRTU, 0, loadEventLine, blockIndex * 32, 32);
            }
            else
            {
                backgroundWorker.CancelAsync();
            }

            waitResponce.Set();
        }

        void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (eventIndex = 0; eventIndex < eventCount; eventIndex++)
            {
                eventData.Add(new ushort[blockCount * 32]);
                serialPort.SetDataRTU(loadEventAddr, serialPort_DataReceived, RequestPriority.Normal, (ushort)(eventIndex + 1));
                waitResponce.WaitOne();
                if (backgroundWorker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                
                for (blockIndex = 0; blockIndex < blockCount; blockIndex++)
                {
                    serialPort.GetDataRTU((ushort)(startDataAddr + 32 * blockIndex), 32, serialPort_LoadDataReceived);
                    waitResponce.WaitOne();
                    if (backgroundWorker.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }
                }
                Array.Copy(loadEventLine, 0, eventData[eventIndex], 0, blockCount * 32);
                backgroundWorker.ReportProgress(eventIndex + 1);
            }
            e.Result = true;
            
        }

        void backgroundWorker_ProgressChanged(object sender,    ProgressChangedEventArgs e)
        {
            if (ProcessUpdate != null) { ProcessUpdate((int)e.ProgressPercentage); }
        }

        void backgroundWorker_RunWorkerCompleted(object sender,    RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                if (LoadindComplete != null) { LoadindComplete(false); return; }
            }
            else
            {
                if (LoadindComplete != null) { LoadindComplete(true); }
            }
        }

        public void CancelLoad()
        {
            backgroundWorker.CancelAsync();
        }

    }
}
