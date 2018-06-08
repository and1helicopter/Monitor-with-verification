using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml;
using FormatsConvert;
using UniSerialPort;
using SerialPorts;
using System.Windows.Forms;

namespace WindowsStructs
{
    public class TimeConfig
    {
        TimeFormats timeFormat = TimeFormats.ADSPFormat;
        public TimeFormats TimeFormat
        {
            get { return timeFormat; }
            set { timeFormat = value; }
        }
        public static TimeFormats StringToTimeFormat(string Value)
        {
            switch (Value)
            {
                case "ADSPFormat": { return TimeFormats.ADSPFormat; }
                case "RTCFormat": { return TimeFormats.RTCFormat; }
                case "STMFormat": { return TimeFormats.STMFormat; }
                default:
                    {
                        throw new Exception("Unknown format!");
                    }

            }

        }


        public static void SendReadTimeRequest(AsynchSerialPort SerialPort, AsynchSerialPort.DataRecievedRTU DataRecieved, TimeConfig CurrentConfig)
        {
            if (CurrentConfig.TimeFormat == TimeFormats.STMFormat)
            {
                SerialPort.GetDataRTU(CurrentConfig.STMProcAddr1, 4, DataRecieved, RequestPriority.Normal);
            }
            else if (CurrentConfig.TimeFormat == TimeFormats.ADSPFormat)
            {
                SerialPort.GetDataRTU(CurrentConfig.ReadAddr, 7, DataRecieved, RequestPriority.Normal);
            }
            else if (CurrentConfig.TimeFormat == TimeFormats.RTCFormat)
            {
                SerialPort.GetDataRTU(CurrentConfig.ReadAddr, 4, DataRecieved, RequestPriority.Normal);
            }
        }

        public static void SendReadTimeRequest(SerialDataProvider SerialPort, Action<bool,ushort[]> DataRecieved, TimeConfig CurrentConfig)
        {
            if (CurrentConfig.TimeFormat == TimeFormats.STMFormat)
            {
                SerialPort.GetData( 1, CurrentConfig.STMProcAddr1, 4, DataRecieved);
            }
            else if (CurrentConfig.TimeFormat == TimeFormats.ADSPFormat)
            {
                SerialPort.GetData( 1, CurrentConfig.ReadAddr, 7, DataRecieved);
            }
            else if (CurrentConfig.TimeFormat == TimeFormats.RTCFormat)
            {
                SerialPort.GetData(1, CurrentConfig.ReadAddr, 4, DataRecieved);
            }
        }

        public static void SendReadTimeRequest(byte SlaveAddr, AsynchSerialPort SerialPort, AsynchSerialPort.DataRecievedRTU DataRecieved, TimeConfig CurrentConfig)
        {
            if (CurrentConfig.TimeFormat == TimeFormats.STMFormat)
            {
                SerialPort.GetDataRTU(SlaveAddr, CurrentConfig.STMProcAddr1, 4, DataRecieved, RequestPriority.Normal);
            }
            else if (CurrentConfig.TimeFormat == TimeFormats.ADSPFormat)
            {
                SerialPort.GetDataRTU(SlaveAddr, CurrentConfig.ReadAddr, 7, DataRecieved, RequestPriority.Normal);
            }
            else if (CurrentConfig.TimeFormat == TimeFormats.RTCFormat)
            {
                SerialPort.GetDataRTU(SlaveAddr, CurrentConfig.ReadAddr, 4, DataRecieved, RequestPriority.Normal);
            }

        }
        public static void SendReadTimeRequest(byte SlaveAddr, SerialDataProvider SerialPort, Action<bool,ushort[]> DataRecieved, TimeConfig CurrentConfig)
        {
            if (CurrentConfig.TimeFormat == TimeFormats.STMFormat)
            {
                SerialPort.GetData(SlaveAddr, CurrentConfig.STMProcAddr1, 4, DataRecieved);
            }
            else if (CurrentConfig.TimeFormat == TimeFormats.ADSPFormat)
            {
                SerialPort.GetData(SlaveAddr, CurrentConfig.ReadAddr, 7, DataRecieved);
            }
            else if (CurrentConfig.TimeFormat == TimeFormats.RTCFormat)
            {
                SerialPort.GetData(SlaveAddr, CurrentConfig.ReadAddr, 4, DataRecieved);
            }

        }


        public static void SendSetTimeRequest(AsynchSerialPort SerialPort, TimeConfig CurrentConfig, int Hour, int Min, int Sec, int Day, int Month, int Year)
        {
            if (CurrentConfig.TimeFormat == TimeFormats.STMFormat)
            {
                ushort[] paramRTU = new ushort[4];
                paramRTU[0] = (ushort)(((Month.ToBCD() & 0x1F) << 8) | (Day.ToBCD() & 0x3F));
                paramRTU[1] = (ushort)Year.ToBCD();
                paramRTU[2] = (ushort)(((Min.ToBCD() & 0xFF) << 8) | (Sec.ToBCD() & 0xFF));
                paramRTU[3] = (ushort)(Hour.ToBCD() | 0x0100);
                SerialPort.SetDataRTU(CurrentConfig.STMProcAddr1_1, null, RequestPriority.Normal, paramRTU);
            }
            else if (CurrentConfig.TimeFormat == TimeFormats.ADSPFormat)
            {
                ushort[] paramRTU = new ushort[3];
                paramRTU[0] = Sec.ToBCD();
                paramRTU[1] = Min.ToBCD();
                paramRTU[2] = Hour.ToBCD(); 
                SerialPort.SetDataRTU(CurrentConfig.SetAddr, null, RequestPriority.Normal, paramRTU);

                paramRTU[0] = Day.ToBCD();
                paramRTU[1] = Month.ToBCD();
                paramRTU[2] = Year.ToBCD();
                SerialPort.SetDataRTU((ushort)(CurrentConfig.SetAddr+4), null, RequestPriority.Normal, paramRTU);

                SerialPort.SetDataRTU(CurrentConfig.AddrSetTime, null, RequestPriority.Normal, 1);
            }
            else if(CurrentConfig.TimeFormat == TimeFormats.RTCFormat)
            {
                ushort[] paramRTU = new ushort[4];
                paramRTU[0] = (ushort)(((Month.ToBCD() & 0x1F) << 8) | (Day.ToBCD() & 0x3F));
                paramRTU[1] = (ushort)Year.ToBCD();
                paramRTU[2] = (ushort)(((Min.ToBCD() & 0x7F) << 8) | (Sec.ToBCD() & 0x7F));
                paramRTU[3] = (ushort)(Hour.ToBCD() & 0x3F);
                SerialPort.SetDataRTU(CurrentConfig.SetAddr, null, RequestPriority.Normal, paramRTU);
            }
        }

        public static void SendSetTimeRequest(SerialDataProvider SerialPort, TimeConfig CurrentConfig, int Hour, int Min, int Sec, int Day, int Month, int Year)
        {
            if (CurrentConfig.TimeFormat == TimeFormats.STMFormat)
            {
                ushort[] paramRTU = new ushort[4];
                paramRTU[0] = (ushort)(((Month.ToBCD() & 0x1F) << 8) | (Day.ToBCD() & 0x3F));
                paramRTU[1] = (ushort)Year.ToBCD();
                paramRTU[2] = (ushort)(((Min.ToBCD() & 0xFF) << 8) | (Sec.ToBCD() & 0xFF));
                paramRTU[3] = (ushort)(Hour.ToBCD() | 0x0100);
                SerialPort.SetData(1, CurrentConfig.STMProcAddr1_1, null, paramRTU);
            }
            else if (CurrentConfig.TimeFormat == TimeFormats.ADSPFormat)
            {
                ushort[] paramRTU = new ushort[3];
                paramRTU[0] = Sec.ToBCD();
                paramRTU[1] = Min.ToBCD();
                paramRTU[2] = Hour.ToBCD();
                SerialPort.SetData(1, CurrentConfig.SetAddr, null, paramRTU);

                paramRTU[0] = Day.ToBCD();
                paramRTU[1] = Month.ToBCD();
                paramRTU[2] = Year.ToBCD();
                SerialPort.SetData(1, (ushort)(CurrentConfig.SetAddr + 4), null,  paramRTU);

                SerialPort.SetData(1, CurrentConfig.AddrSetTime, null,  1);
            }
            else if (CurrentConfig.TimeFormat == TimeFormats.RTCFormat)
            {
                ushort[] paramRTU = new ushort[4];
                paramRTU[0] = (ushort)(((Month.ToBCD() & 0x1F) << 8) | (Day.ToBCD() & 0x3F));
                paramRTU[1] = (ushort)Year.ToBCD();
                paramRTU[2] = (ushort)(((Min.ToBCD() & 0x7F) << 8) | (Sec.ToBCD() & 0x7F));
                paramRTU[3] = (ushort)(Hour.ToBCD() & 0x3F);
                SerialPort.SetData(1,CurrentConfig.SetAddr, null, paramRTU);
            }

        }

        public static string ExtractTimeFromArray(ushort[] ParamRTU, TimeConfig CurrentConfig,  int Index = 0)
        {
            return ExtractTimeFromArray(ParamRTU, CurrentConfig.timeFormat, Index);
        }

        public static void SendSetTimeRequest(byte SlaveAddr, AsynchSerialPort SerialPort, TimeConfig CurrentConfig, int Hour, int Min, int Sec, int Day, int Month, int Year)
        {
            if (CurrentConfig.TimeFormat == TimeFormats.STMFormat)
            {
                ushort[] paramRTU = new ushort[4];
                paramRTU[0] = (ushort)(((Month.ToBCD() & 0x1F) << 8) | (Day.ToBCD() & 0x3F));
                paramRTU[1] = (ushort)Year.ToBCD();
                paramRTU[2] = (ushort)(((Min.ToBCD() & 0xFF) << 8) | (Sec.ToBCD() & 0xFF));
                paramRTU[3] = (ushort)(Hour.ToBCD() | 0x0100);
                SerialPort.SetDataRTU(SlaveAddr, CurrentConfig.STMProcAddr1_1, null, RequestPriority.Normal, paramRTU);
            }
            else if (CurrentConfig.TimeFormat == TimeFormats.ADSPFormat)
            {
                ushort[] paramRTU = new ushort[3];
                paramRTU[0] = Sec.ToBCD();
                paramRTU[1] = Min.ToBCD();
                paramRTU[2] = Hour.ToBCD();
                SerialPort.SetDataRTU(SlaveAddr, CurrentConfig.SetAddr, null, RequestPriority.Normal, paramRTU);

                paramRTU[0] = Day.ToBCD();
                paramRTU[1] = Month.ToBCD();
                paramRTU[2] = Year.ToBCD();
                SerialPort.SetDataRTU(SlaveAddr, (ushort)(CurrentConfig.SetAddr + 4), null, RequestPriority.Normal, paramRTU);

                SerialPort.SetDataRTU(SlaveAddr, CurrentConfig.AddrSetTime, null, RequestPriority.Normal, 1);
            }
            if (CurrentConfig.TimeFormat == TimeFormats.RTCFormat)
            {
                ushort[] paramRTU = new ushort[4];
                paramRTU[0] = (ushort)(((Month.ToBCD() & 0x1F) << 8) | (Day.ToBCD() & 0x3F));
                paramRTU[1] = (ushort)Year.ToBCD();
                paramRTU[2] = (ushort)(((Min.ToBCD() & 0x7F) << 8) | (Sec.ToBCD() & 0x7F));
                paramRTU[3] = (ushort)(Hour.ToBCD() & 0x3F);
                SerialPort.SetDataRTU(SlaveAddr, CurrentConfig.SetAddr, null, RequestPriority.Normal, paramRTU);
            }
        }

        public static void SendSetTimeRequest(byte SlaveAddr, SerialDataProvider SerialPort, TimeConfig CurrentConfig, int Hour, int Min, int Sec, int Day, int Month, int Year)
        {
            if (CurrentConfig.TimeFormat == TimeFormats.STMFormat)
            {
                ushort[] paramRTU = new ushort[4];
                paramRTU[0] = (ushort)(((Month.ToBCD() & 0x1F) << 8) | (Day.ToBCD() & 0x3F));
                paramRTU[1] = (ushort)Year.ToBCD();
                paramRTU[2] = (ushort)(((Min.ToBCD() & 0xFF) << 8) | (Sec.ToBCD() & 0xFF));
                paramRTU[3] = (ushort)(Hour.ToBCD() | 0x0100);
                SerialPort.SetData(SlaveAddr, CurrentConfig.STMProcAddr1_1, null,  paramRTU);
            }
            else if (CurrentConfig.TimeFormat == TimeFormats.ADSPFormat)
            {
                ushort[] paramRTU = new ushort[3];
                paramRTU[0] = Sec.ToBCD();
                paramRTU[1] = Min.ToBCD();
                paramRTU[2] = Hour.ToBCD();
                SerialPort.SetData(SlaveAddr, CurrentConfig.SetAddr, null, paramRTU);

                paramRTU[0] = Day.ToBCD();
                paramRTU[1] = Month.ToBCD();
                paramRTU[2] = Year.ToBCD();
                SerialPort.SetData(SlaveAddr, (ushort)(CurrentConfig.SetAddr + 4), null, paramRTU);

                SerialPort.SetData(SlaveAddr, CurrentConfig.AddrSetTime, null, 1);
            }
            if (CurrentConfig.TimeFormat == TimeFormats.RTCFormat)
            {
                ushort[] paramRTU = new ushort[4];
                paramRTU[0] = (ushort)(((Month.ToBCD() & 0x1F) << 8) | (Day.ToBCD() & 0x3F));
                paramRTU[1] = (ushort)Year.ToBCD();
                paramRTU[2] = (ushort)(((Min.ToBCD() & 0x7F) << 8) | (Sec.ToBCD() & 0x7F));
                paramRTU[3] = (ushort)(Hour.ToBCD() & 0x3F);
                SerialPort.SetData(SlaveAddr, CurrentConfig.SetAddr, null, paramRTU);
            }
        }

        public static string[] ExtractArrayTimeFromArray(ushort[] ParamRTU, TimeFormats TimeF)
        {

            if (TimeF == TimeFormats.STMFormat)
            {
                string[] strs = new string[6];
                if (ParamRTU.Length != 4)
                {
                    throw new Exception("Invalid data!");
                }

                strs[0] = (ParamRTU[3] & 0x00FF).ToString("X2");
                strs[1] = ((ParamRTU[2] >> 8) & 0x00FF).ToString("X2");
                strs[2] = (ParamRTU[2] & 0x00FF).ToString("X2");
                strs[3] = (ParamRTU[0] & 0x003F).ToString("X2");
                strs[4] = ((ParamRTU[0] >> 8) & 0x001F).ToString("X2");
                strs[5] = "20" + (ParamRTU[1] & 0x00FF).ToString("X2");
                return strs;
            }
            else if (TimeF == TimeFormats.ADSPFormat)
            {
                string[] strs = new string[6];
                if (ParamRTU.Length != 7)
                {
                    throw new Exception("Invalid data!");
                }

                string str = "";
                str = str + (ParamRTU[2] & 0x00FF).ToString("X2") + ":";
                str = str + (ParamRTU[1] & 0x00FF).ToString("X2") + ":" + (ParamRTU[0] & 0x00FF).ToString("X2") + " ";

                str = str + (ParamRTU[4] & 0x00FF).ToString("X2") + "/" + (ParamRTU[5] & 0x001F).ToString("X2") + "/";
                str = str + "20" + (ParamRTU[6] & 0x00FF).ToString("X2");

                strs[0] = (ParamRTU[2] & 0x00FF).ToString("X2");
                strs[1] = (ParamRTU[1] & 0x00FF).ToString("X2");
                strs[2] = (ParamRTU[0] & 0x00FF).ToString("X2");
                strs[3] = (ParamRTU[4] & 0x00FF).ToString("X2");
                strs[4] = (ParamRTU[5] & 0x001F).ToString("X2");
                strs[5] = "20" + (ParamRTU[6] & 0x00FF).ToString("X2");
                return strs;

            }
            else if (TimeF == TimeFormats.RTCFormat)
            {
                string[] strs = new string[6];
                if (ParamRTU.Length != 4)
                {
                    throw new Exception("Invalid data!");
                }

                strs[0] = ConvertFuncs.FromBCD((ushort)(ParamRTU[3] & 0x003F)).ToString("D2");
                strs[1] = ConvertFuncs.FromBCD((ushort)((ParamRTU[2] & 0xFF00) >> 8)).ToString("D2");
                strs[2] = ConvertFuncs.FromBCD((ushort)(ParamRTU[2] & 0x00FF)).ToString("D2");
                strs[3] = ConvertFuncs.FromBCD((ushort)(ParamRTU[0] & 0x003F)).ToString("D2");
                strs[4] = ConvertFuncs.FromBCD((ushort)((ParamRTU[0] & 0x1F00) >> 8)).ToString("D2");
                strs[5] = "20" + ConvertFuncs.FromBCD((ushort)(ParamRTU[1] & 0x00FF)).ToString("D2");

                return strs;
            }
            return null;
        }

        public static string ExtractTimeFromArray(ushort[] ParamRTU, TimeFormats TimeF, int Index = 0)
        {
            if (TimeF == TimeFormats.STMFormat)
            {
                if (ParamRTU.Length - Index < 4)
                {
                    throw new Exception("Invalid data!");
                }

                string str = "";
                str = str + (ParamRTU[3 + Index] & 0x00FF).ToString("X2")+":";
                str = str + ((ParamRTU[2 + Index] >> 8) & 0x00FF).ToString("X2") + ":" + (ParamRTU[2 + Index] & 0x00FF).ToString("X2")+" ";

                str = str +(ParamRTU[0 + Index] & 0x003F).ToString("X2") + "/" + ((ParamRTU[0 + Index] >> 8) & 0x001F).ToString("X2") + "/";
                str = str + "20" + (ParamRTU[1 + Index] & 0x00FF).ToString("X2");
                return str;
            }
            else if (TimeF == TimeFormats.ADSPFormat)
            {
                if (ParamRTU.Length - Index < 7)
                {
                    throw new Exception("Invalid data!");
                }

                string str = "";

                str = (ParamRTU[4 + Index] & 0x00FF).ToString("X2") + "/" + (ParamRTU[5 + Index] & 0x001F).ToString("X2") + "/" +
                      "20" + (ParamRTU[6 + Index] & 0x00FF).ToString("X2") + " " +
                       (ParamRTU[2 + Index] & 0x00FF).ToString("X2") + ":" +
                        (ParamRTU[1 + Index] & 0x00FF).ToString("X2") + ":" + (ParamRTU[0 + Index] & 0x00FF).ToString("X2")/* + "." + (ParamRTU[3]).ToString("D3")*/;

                
                return str;

            }
            else if (TimeF == TimeFormats.RTCFormat)
            {
                if (ParamRTU.Length - Index < 4)
                {
                    throw new Exception("Invalid data!");
                }

                string str = "";

                str = ConvertFuncs.FromBCD((ushort)(ParamRTU[0 + Index] & 0x003F)).ToString("D2") + " / " + ConvertFuncs.FromBCD((ushort)((ParamRTU[0 + Index] & 0x1F00) >> 8)).ToString("D2") + " / " +
                      "20" + ConvertFuncs.FromBCD((ushort)(ParamRTU[1 + Index] & 0x00FF)).ToString("D2") + "   " +
                       ConvertFuncs.FromBCD((ushort)(ParamRTU[3 + Index] & 0x003F)).ToString("D2") + ":" +
                        ConvertFuncs.FromBCD((ushort)((ParamRTU[2 + Index] & 0xFF00) >> 8)).ToString("D2") + ":" + ConvertFuncs.FromBCD((ushort)(ParamRTU[2 + Index] & 0x00FF)).ToString("D2") + 
                        "." + (ParamRTU[3 + Index] >>6).ToString("D3");


                return str;

            }
            return "";
        }

        public TimeConfig()
        {

        }

        public TimeConfig(XElement TimeXElement)
        {
            try
            {
                timeFormat = StringToTimeFormat(TimeXElement.Attribute("TimeFormat").Value);
            }
            catch 
            {
                throw new Exception("Error time format!");
            }


            if (timeFormat == TimeFormats.STMFormat)
            {
                try
                {
                    STMProcAddr1 = ConvertFuncs.UInt16ToWord(TimeXElement.Attribute("STMProcAddr1").Value);
                    STMProcAddr2 = ConvertFuncs.UInt16ToWord(TimeXElement.Attribute("STMProcAddr2").Value);
                    STMProcAddr3 = ConvertFuncs.UInt16ToWord(TimeXElement.Attribute("STMProcAddr3").Value);
                    STMProcAddr4 = ConvertFuncs.UInt16ToWord(TimeXElement.Attribute("STMProcAddr4").Value);

                    STMProcAddr1_1 = ConvertFuncs.UInt16ToWord(TimeXElement.Attribute("STMProcAddr1_1").Value);
                    STMProcAddr2_1 = ConvertFuncs.UInt16ToWord(TimeXElement.Attribute("STMProcAddr2_1").Value);
                    STMProcAddr3_1 = ConvertFuncs.UInt16ToWord(TimeXElement.Attribute("STMProcAddr3_1").Value);
                    STMProcAddr4_1 = ConvertFuncs.UInt16ToWord(TimeXElement.Attribute("STMProcAddr4_1").Value);
                }
                catch
                {
                     throw new Exception("Error time format!");
                }
            }
            else if (timeFormat == TimeFormats.ADSPFormat)
            {
                try
                {
                    ReadAddr = ConvertFuncs.UInt16ToWord(TimeXElement.Attribute("ReadAddr").Value);
                    SetAddr = ConvertFuncs.UInt16ToWord(TimeXElement.Attribute("SetAddr").Value);
                    AddrSetTime = ConvertFuncs.UInt16ToWord(TimeXElement.Attribute("AddrSetTime").Value);
                }
                catch
                {
                    throw new Exception("Error time format!");
                }

            }
            else if (timeFormat == TimeFormats.RTCFormat)
            {
                try
                {
                    ReadAddr = ConvertFuncs.UInt16ToWord(TimeXElement.Attribute("ReadAddr").Value);
                    SetAddr = ConvertFuncs.UInt16ToWord(TimeXElement.Attribute("SetAddr").Value);
                }
                catch
                {
                    throw new Exception("Error time format!");
                }

            }
        }
        public void AppendTimeXMLNode(XmlDocument XmlDocument)
        {
            XmlNode element = XmlDocument.CreateElement("TimeSettings");
            XmlDocument.DocumentElement.AppendChild(element); // указываем родителя

            XmlAttribute attribute = XmlDocument.CreateAttribute("TimeFormat"); // создаём атрибут
            attribute.Value = timeFormat.ToString();
            element.Attributes.Append(attribute); // добавляем атрибут

            if (timeFormat == TimeFormats.ADSPFormat)
            {
                attribute = XmlDocument.CreateAttribute("ReadAddr"); // создаём атрибут
                attribute.Value = ReadAddr.ToString();
                element.Attributes.Append(attribute); // добавляем атрибут


                attribute = XmlDocument.CreateAttribute("SetAddr"); // создаём атрибут
                attribute.Value = SetAddr.ToString();
                element.Attributes.Append(attribute); // добавляем атрибут

                attribute = XmlDocument.CreateAttribute("AddrSetTime"); // создаём атрибут
                attribute.Value = AddrSetTime.ToString();
                element.Attributes.Append(attribute); // добавляем атрибут
            }

            if (timeFormat == TimeFormats.STMFormat)
            {

                attribute = XmlDocument.CreateAttribute("STMProcAddr1"); // создаём атрибут
                attribute.Value = STMProcAddr1.ToString();
                element.Attributes.Append(attribute); // добавляем атрибут

                attribute = XmlDocument.CreateAttribute("STMProcAddr2"); // создаём атрибут
                attribute.Value = STMProcAddr2.ToString();
                element.Attributes.Append(attribute); // добавляем атрибут

                attribute = XmlDocument.CreateAttribute("STMProcAddr3"); // создаём атрибут
                attribute.Value = STMProcAddr3.ToString();
                element.Attributes.Append(attribute); // добавляем атрибут

                attribute = XmlDocument.CreateAttribute("STMProcAddr4"); // создаём атрибут
                attribute.Value = STMProcAddr4.ToString();
                element.Attributes.Append(attribute); // добавляем атрибут

                attribute = XmlDocument.CreateAttribute("STMProcAddr1_1"); // создаём атрибут
                attribute.Value = STMProcAddr1_1.ToString();
                element.Attributes.Append(attribute); // добавляем атрибут

                attribute = XmlDocument.CreateAttribute("STMProcAddr2_1"); // создаём атрибут
                attribute.Value = STMProcAddr2_1.ToString();
                element.Attributes.Append(attribute); // добавляем атрибут

                attribute = XmlDocument.CreateAttribute("STMProcAddr3_1"); // создаём атрибут
                attribute.Value = STMProcAddr3_1.ToString();
                element.Attributes.Append(attribute); // добавляем атрибут

                attribute = XmlDocument.CreateAttribute("STMProcAddr4_1"); // создаём атрибут
                attribute.Value = STMProcAddr4_1.ToString();
                element.Attributes.Append(attribute); // добавляем атрибут
            }
            if (timeFormat == TimeFormats.RTCFormat)
            {
                attribute = XmlDocument.CreateAttribute("ReadAddr"); // создаём атрибут
                attribute.Value = ReadAddr.ToString();
                element.Attributes.Append(attribute); // добавляем атрибут


                attribute = XmlDocument.CreateAttribute("SetAddr"); // создаём атрибут
                attribute.Value = SetAddr.ToString();
                element.Attributes.Append(attribute); // добавляем атрибут

            }
        }

        //Адреса для чтения
        public ushort STMProcAddr1 = 0x0002;
        public ushort STMProcAddr2 = 0x0003;
        public ushort STMProcAddr3 = 0x0004;
        public ushort STMProcAddr4 = 0x0005;

        //Адреса для записи
        public ushort STMProcAddr1_1 = 0x0002;
        public ushort STMProcAddr2_1 = 0x0003;
        public ushort STMProcAddr3_1 = 0x0004;
        public ushort STMProcAddr4_1 = 0x0005;

        //Старый формат
        public ushort ReadAddr = 0x0202;
        public ushort SetAddr = 0x0259;
        public ushort AddrSetTime = 0x0252;

    }
}
