using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using FormatsConvert;
using System.Collections;

namespace WindowsStructs
{
    public class SystemConfiguration
    {
        List<DigitPlate> digitPlates = new List<DigitPlate>();
        public List<DigitPlate> DigitPlates
        {
            get { return digitPlates; }
            set { digitPlates = value; }
        }

        List<MeasureParam> measureParams = new List<MeasureParam>();
        public List<MeasureParam> MeasureParams
        {
            get { return measureParams; }
            set { measureParams = value; }
        }

        Hashtable eventCodes = new Hashtable();
        public Hashtable EventCodes
        {
            get { return eventCodes; }
            set { eventCodes = value; }
        }

        ushort startMeasureAddr = 0x0200;
        public ushort StartMeasureAddr
        {
            get { return startMeasureAddr; }
            set { startMeasureAddr = value; }
        }

        ushort eventCodeAddr = 0x0000;
        public ushort EventCodeAddr
        {
            get { return eventCodeAddr; }
            set { eventCodeAddr = value; }
        }

        ushort eventTimeAddr = 0x0002;
        public ushort EventTimeAddr
        {
            get { return eventTimeAddr; }
            set { eventTimeAddr = value; }
        }

        ushort eventBlockCount = 2;
        public ushort EventBlockCount
        {
            get { return eventBlockCount; }
            set { eventBlockCount = value; }
        }

        ushort loadEventAddr = 0x0251;
        public ushort LoadEventAddr
        {
            get { return loadEventAddr; }
            set { loadEventAddr = value; }
        }

        ushort loadEventDataAddr = 0x0228;
        public ushort LoadEventDataAddr
        {
            get { return loadEventDataAddr; }
            set { loadEventDataAddr = value; }
        }

        ushort eventCount = 50;
        public ushort EventCount
        {
            get { return eventCount; }
            set { eventCount = value; }
        }

        bool enaDigits = true;
        public bool EnaDigits
        {
            get { return enaDigits; }
            set { enaDigits = value; }
        }

        bool enaDirectAccess = true;
        public bool EnaDirectAccess
        {
            get { return enaDirectAccess; }
            set { enaDirectAccess = value; }
        }

        bool enaFloatDirectAccess = true;
        public bool EnaFloatDirectAccess
        {
            get { return enaFloatDirectAccess; }
            set { enaFloatDirectAccess = value; }
        }

        bool enaLoadSyms = true;
        public bool EnaLoadSyms
        {
            get { return enaLoadSyms; }
            set { enaLoadSyms = value; }
        }

        bool enaScope = true;
        public bool EnaScope
        {
            get { return enaScope; }
            set { enaScope = value; }
        }

        bool enaEventLog = true;
        public bool EnaEventLog
        {
            get { return enaEventLog; }
            set { enaEventLog = value; }
        }

        bool enaJog = false;
        public bool EnaJog
        {
            get { return enaJog; }
            set { enaJog = value; }
        }

        bool enaAngle = false;
        public bool EnaAngle
        {
            get { return enaAngle; }
            set { enaAngle = value; }
        }

        bool enaForceDig = false;
        public bool EnaForceDig
        {
            get { return enaForceDig; }
            set { enaForceDig = value; }
        }

        List<WarningParam> warningParams = new List<WarningParam>();
        public List<WarningParam> WarningParams
        {
            get { return warningParams; }
            set { warningParams = value; }
        }

        List<WarningParam> alarmParams = new List<WarningParam>();
        public List<WarningParam> AlarmParams
        {
            get { return alarmParams; }
            set { alarmParams = value; }
        }

        List<WarningParam> readyParams = new List<WarningParam>();
        public List<WarningParam> ReadyParams
        {
            get { return readyParams; }
            set { readyParams = value; }
        }

        
        TimeConfig timeConfig = new TimeConfig();

        public TimeConfig TimeConfig
        {
            get { return timeConfig; }
            set { timeConfig = value; }
        }

        public void SaveToFile()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = ".xml";
            sfd.Filter = "XML-файлы|*.xml";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                SaveToFileBody(sfd.FileName);
            }
        }

        public void SaveToFile(string FileName)
        {
            SaveToFileBody(FileName);
        }

        void SaveToFileBody(string FileName)
        {
            try
            {
                XmlTextWriter textWritter = new XmlTextWriter(FileName, Encoding.UTF8);
                textWritter.WriteStartDocument();
                textWritter.WriteStartElement("Setup");
                textWritter.WriteEndElement();
                textWritter.Close();
            }
            catch
            {
                MessageBox.Show("Не удалось создать XML-файл!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            XmlDocument document = new XmlDocument();
            try
            {
                document.Load(FileName);
            }
            catch
            {
                MessageBox.Show("Не удалось создать XML-файл!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            #region Digits
            XmlNode element = document.CreateElement("Digits");
            document.DocumentElement.AppendChild(element); // указываем родителя

            XmlAttribute attribute = document.CreateAttribute("Count"); // создаём атрибут
            attribute.Value = digitPlates.Count.ToString();
            element.Attributes.Append(attribute); // добавляем атрибут
            #endregion

            #region DigitN
            for (int i = 0; i < digitPlates.Count; i++)
            {
                element = document.CreateElement("Digit" + (i + 1).ToString());
                document.DocumentElement.AppendChild(element);

                attribute = document.CreateAttribute("Type"); // создаём атрибут
                attribute.Value = digitPlates[i].DigitType.ToString();
                element.Attributes.Append(attribute); // добавляем атрибут

                attribute = document.CreateAttribute("Invert"); // создаём атрибут
                attribute.Value = digitPlates[i].Invert.ToString();
                element.Attributes.Append(attribute); // добавляем атрибут

                attribute = document.CreateAttribute("Addr"); // создаём атрибут
                attribute.Value = "0x"+digitPlates[i].StartAddr.ToString("X4");
                element.Attributes.Append(attribute); // добавляем атрибут

                attribute = document.CreateAttribute("EventPos"); // создаём атрибут
                attribute.Value = "0x"+digitPlates[i].EventStructAddr.ToString("X4");
                element.Attributes.Append(attribute); // добавляем атрибут

                attribute = document.CreateAttribute("Title"); // создаём атрибут
                attribute.Value = digitPlates[i].Titl.ToString();
                element.Attributes.Append(attribute); // добавляем атрибут

                attribute = document.CreateAttribute("UseMask"); // создаём атрибут
                attribute.Value = digitPlates[i].UseMask.ToString();
                element.Attributes.Append(attribute); // добавляем атрибут

                for (int i2 = 0; i2 < 16; i2++)
                {
                    attribute = document.CreateAttribute("Line" + (i2).ToString()); // создаём атрибут
                    attribute.Value = digitPlates[i].DigitNames[i2];
                    element.Attributes.Append(attribute); // добавляем атрибут
                }

            }
            #endregion

            #region MeasureParams
            element = document.CreateElement("MeasureParams");
            document.DocumentElement.AppendChild(element); // указываем родителя

            attribute = document.CreateAttribute("Count"); // создаём атрибут
            attribute.Value = MeasureParams.Count.ToString();
            element.Attributes.Append(attribute); // добавляем атрибут
            #endregion

            #region MeasureParamN
            for (int i = 0; i < measureParams.Count; i++)
            {
                element = document.CreateElement("MeasureParam" + (i + 1).ToString());
                document.DocumentElement.AppendChild(element);

                attribute = document.CreateAttribute("Name"); // создаём атрибут
                attribute.Value = measureParams[i].ParameterName;
                element.Attributes.Append(attribute); // добавляем атрибут

                attribute = document.CreateAttribute("Addr"); // создаём атрибут
                attribute.Value = "0x" + measureParams[i].Addr.ToString("X4");
                element.Attributes.Append(attribute); // добавляем атрибут

                attribute = document.CreateAttribute("Format"); // создаём атрибут
                attribute.Value = measureParams[i].Format.ToString();
                element.Attributes.Append(attribute); // добавляем атрибут
            }
            #endregion

            #region EventCodes
            element = document.CreateElement("EventCodes");
            document.DocumentElement.AppendChild(element); // указываем родителя

            attribute = document.CreateAttribute("Count"); // создаём атрибут
            attribute.Value = EventCodes.Count.ToString();
            element.Attributes.Append(attribute); // добавляем атрибут
            #endregion

            #region EvenCodeN
            ICollection keys = eventCodes.Keys;
            int eventindex = 0;
            foreach (string s in keys)
            {
                element = document.CreateElement("EventCode" + (++eventindex).ToString());
                document.DocumentElement.AppendChild(element);

                attribute = document.CreateAttribute("Code"); // создаём атрибут
                attribute.Value = s;
                element.Attributes.Append(attribute); // добавляем атрибут

                attribute = document.CreateAttribute("Name"); // создаём атрибут
                attribute.Value = eventCodes[s].ToString();
                element.Attributes.Append(attribute); // добавляем атрибут
            }
            #endregion

            #region OtherParams
            element = document.CreateElement("OtherParams");
            document.DocumentElement.AppendChild(element); // указываем родителя

            attribute = document.CreateAttribute("StartMeasureAddr"); // создаём атрибут
            attribute.Value = "0x" + StartMeasureAddr.ToString("X4");
            element.Attributes.Append(attribute); // добавляем атрибут

            attribute = document.CreateAttribute("EventCodeAddr"); // создаём атрибут
            attribute.Value = "0x" + EventCodeAddr.ToString("X4");
            element.Attributes.Append(attribute); // добавляем атрибут

            attribute = document.CreateAttribute("EventTimeAddr"); // создаём атрибут
            attribute.Value = "0x" + EventTimeAddr.ToString("X4");
            element.Attributes.Append(attribute); // добавляем атрибут

            attribute = document.CreateAttribute("EventBlockCount"); // создаём атрибут
            attribute.Value = "0x" + EventBlockCount.ToString("X4");
            element.Attributes.Append(attribute); // добавляем атрибут

            attribute = document.CreateAttribute("LoadEventAddr"); // создаём атрибут
            attribute.Value = "0x" + LoadEventAddr.ToString("X4");
            element.Attributes.Append(attribute); // добавляем атрибут

            attribute = document.CreateAttribute("LoadEventDataAddr"); // создаём атрибут
            attribute.Value = "0x" + LoadEventDataAddr.ToString("X4");
            element.Attributes.Append(attribute); // добавляем атрибут

            attribute = document.CreateAttribute("EventCount"); // создаём атрибут
            attribute.Value = EventCount.ToString();
            element.Attributes.Append(attribute); // добавляем атрибут

            if (EnaDigits)
            {
                attribute = document.CreateAttribute("EnaDigits"); // создаём атрибут
                attribute.Value = "1";
                element.Attributes.Append(attribute); // добавляем атрибут
            }

            if (EnaDirectAccess)
            {
                attribute = document.CreateAttribute("EnaDirectAccess"); // создаём атрибут
                attribute.Value = "1";
                element.Attributes.Append(attribute); // добавляем атрибут
            }

            if (EnaFloatDirectAccess)
            {
                attribute = document.CreateAttribute("EnaFloatDirectAccess"); // создаём атрибут
                attribute.Value = "1";
                element.Attributes.Append(attribute); // добавляем атрибут
            }

            if (EnaScope)
            {
                attribute = document.CreateAttribute("EnaScope"); // создаём атрибут
                attribute.Value = "1";
                element.Attributes.Append(attribute); // добавляем атрибут
            }

            if (EnaLoadSyms)
            {
                attribute = document.CreateAttribute("EnaLoadSyms"); // создаём атрибут
                attribute.Value = "1";
                element.Attributes.Append(attribute); // добавляем атрибут
            }

            if (EnaEventLog)
            {
                attribute = document.CreateAttribute("EnaEventLog"); // создаём атрибут
                attribute.Value = "1";
                element.Attributes.Append(attribute); // добавляем атрибут
            }

            if (EnaJog)
            {
                attribute = document.CreateAttribute("EnaJog"); // создаём атрибут
                attribute.Value = "1";
                element.Attributes.Append(attribute); // добавляем атрибут
            }

            if (EnaAngle)
            {
                attribute = document.CreateAttribute("EnaAngle"); // создаём атрибут
                attribute.Value = "1";
                element.Attributes.Append(attribute); // добавляем атрибут
            }

            if (EnaForceDig)
            {
                attribute = document.CreateAttribute("EnaForceDig"); // создаём атрибут
                attribute.Value = "1";
                element.Attributes.Append(attribute); // добавляем атрибут
            }


            #endregion

            #region Warnings
            element = document.CreateElement("Warnings");
            document.DocumentElement.AppendChild(element); // указываем родителя

            attribute = document.CreateAttribute("Count"); // создаём атрибут
            attribute.Value = warningParams.Count.ToString();
            element.Attributes.Append(attribute); // добавляем атрибут
            #endregion

            #region WarningN
            for (int i = 0; i < warningParams.Count; i++)
            {
                element = document.CreateElement("Warning" + (i + 1).ToString());
                document.DocumentElement.AppendChild(element);


                attribute = document.CreateAttribute("Addr"); // создаём атрибут
                attribute.Value = "0x" + warningParams[i].EventPosAddr.ToString("X4");
                element.Attributes.Append(attribute); // добавляем атрибут


                attribute = document.CreateAttribute("Title"); // создаём атрибут
                attribute.Value = warningParams[i].Titl.ToString();
                element.Attributes.Append(attribute); // добавляем атрибут


                for (int i2 = 0; i2 < 16; i2++)
                {
                    attribute = document.CreateAttribute("Line" + (i2).ToString()); // создаём атрибут
                    attribute.Value = warningParams[i].Names[i2];
                    element.Attributes.Append(attribute); // добавляем атрибут
                }

            }
            #endregion

            #region Alarms
            element = document.CreateElement("Alarms");
            document.DocumentElement.AppendChild(element); // указываем родителя

            attribute = document.CreateAttribute("Count"); // создаём атрибут
            attribute.Value = alarmParams.Count.ToString();
            element.Attributes.Append(attribute); // добавляем атрибут
            #endregion

            #region AlarmN
            for (int i = 0; i < alarmParams.Count; i++)
            {
                element = document.CreateElement("Alarm" + (i + 1).ToString());
                document.DocumentElement.AppendChild(element);


                attribute = document.CreateAttribute("Addr"); // создаём атрибут
                attribute.Value = "0x" + alarmParams[i].EventPosAddr.ToString("X4");
                element.Attributes.Append(attribute); // добавляем атрибут


                attribute = document.CreateAttribute("Title"); // создаём атрибут
                attribute.Value = alarmParams[i].Titl.ToString();
                element.Attributes.Append(attribute); // добавляем атрибут


                for (int i2 = 0; i2 < 16; i2++)
                {
                    attribute = document.CreateAttribute("Line" + (i2).ToString()); // создаём атрибут
                    attribute.Value = alarmParams[i].Names[i2];
                    element.Attributes.Append(attribute); // добавляем атрибут
                }

            }
            #endregion

            #region Readys
            element = document.CreateElement("Readys");
            document.DocumentElement.AppendChild(element); // указываем родителя

            attribute = document.CreateAttribute("Count"); // создаём атрибут
            attribute.Value = readyParams.Count.ToString();
            element.Attributes.Append(attribute); // добавляем атрибут
            #endregion

            #region ReadyN
            for (int i = 0; i < readyParams.Count; i++)
            {
                element = document.CreateElement("Ready" + (i + 1).ToString());
                document.DocumentElement.AppendChild(element);


                attribute = document.CreateAttribute("Addr"); // создаём атрибут
                attribute.Value = "0x" + readyParams[i].EventPosAddr.ToString("X4");
                element.Attributes.Append(attribute); // добавляем атрибут


                attribute = document.CreateAttribute("Title"); // создаём атрибут
                attribute.Value = readyParams[i].Titl.ToString();
                element.Attributes.Append(attribute); // добавляем атрибут


                for (int i2 = 0; i2 < 16; i2++)
                {
                    attribute = document.CreateAttribute("Line" + (i2).ToString()); // создаём атрибут
                    attribute.Value = readyParams[i].Names[i2];
                    element.Attributes.Append(attribute); // добавляем атрибут
                }

            }
            #endregion

            timeConfig.AppendTimeXMLNode(document);

            try
            {
                document.Save(FileName);
            }
            catch
            {
                MessageBox.Show("Не удалось создать XML-файл!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        public void LoadFromFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.DefaultExt = ".xml";
            ofd.Filter = "XML-файлы|*.xml";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                OpenFileBody(ofd.FileName);
            }

        }

        public void LoadFromFile(String FileName)
        {
            OpenFileBody(FileName);
        }

        void OpenFileBody(string FileName)
        {
            XDocument document;
            try
            {
                document = XDocument.Load(FileName);

            }
            catch
            {
                throw new Exception("Error open xml file!");
            }
            digitPlates = new List<DigitPlate>();

            int digitCount = 0;
            try
            {
                XElement element = document.Root.Element("Digits");
                digitCount = Convert.ToInt16(element.Attribute("Count").Value.ToString(), 10);
            }
            catch
            {
                digitCount = 0;
               //throw new Exception("Errors in part Digits of xml file!");
            }

            for (int i = 0; i < digitCount; i++)
            {
                try
                {
                    XElement element = document.Root.Element("Digit" + (i + 1).ToString());
                    DigitPlate dp = new DigitPlate();
                    dp.Titl = element.Attribute("Title").Value;


                    if (element.Attribute("Type").Value == "DigInput")
                    {
                        dp.DigitType = DigitType.DigInput;
                    }
                    else
                    {
                        dp.DigitType = DigitType.DigOutput;
                    }

                    if (element.Attribute("Invert").Value.ToString().ToUpper() == "TRUE")
                    {
                        dp.Invert = true;
                    }
                    else
                    {
                        dp.Invert = false;
                    }


                    dp.StartAddr = (ushort)ConvertFuncs.StrToShort(element.Attribute("Addr").Value.ToString());
                    dp.EventStructAddr = (ushort)ConvertFuncs.StrToShort(element.Attribute("EventPos").Value.ToString());

                    dp.UseMask = Convert.ToUInt16(element.Attribute("UseMask").Value, 10);
                    for (int i2 = 0; i2 < 16; i2++)
                    {
                        dp.DigitNames[i2] = element.Attribute("Line"+(i2).ToString()).Value;
                    }



                    digitPlates.Add(dp);
                }
                catch
                {
                    throw new Exception("Errors in part Digit"+ (i+1).ToString()+" of xml file!");
                }
            }


            int measureCount = 0;
            measureParams = new List<MeasureParam>();
            try
            {
                XElement element = document.Root.Element("MeasureParams");
                measureCount = Convert.ToInt16(element.Attribute("Count").Value.ToString(), 10);
            }
            catch
            {
                measureCount = 0;
                //throw new Exception("Errors in part MeasureParams of xml file!");
            }

            for (int i = 0; i < measureCount; i++)
            {
                try
                {
                    XElement element = document.Root.Element("MeasureParam" + (i + 1).ToString());
                    string str1,str2,str3;
                    str1 = element.Attribute("Name").Value;
                    str2 = element.Attribute("Addr").Value;
                    str3 = element.Attribute("Format").Value;

                    MeasureParam dp = new MeasureParam(str1, str2, str3);
                    measureParams.Add(dp);    
                }
                catch
                {
                    throw new Exception("Errors in part MeasureParam" + (i + 1).ToString() + " of xml file!");
                }
            }

            int eventCount = 0;
            eventCodes = new Hashtable();
            try
            {
                XElement element = document.Root.Element("EventCodes");
                eventCount = Convert.ToInt16(element.Attribute("Count").Value.ToString(), 10);
            }
            catch
            {
                eventCount = 0;
                //throw new Exception("Errors in part MeasureParams of xml file!");
            }


            for (int i = 0; i < eventCount; i++)
            {
                try
                {
                    XElement element = document.Root.Element("EventCode" + (i + 1).ToString());
                    string str1, str2;
                    str1 = element.Attribute("Name").Value;
                    str2 = element.Attribute("Code").Value;
                    eventCodes.Add(str2, str1);
                }
                catch
                {
                    throw new Exception("Errors in part EventCode" + (i + 1).ToString() + " of xml file!");
                }
            }

            try
            {
                XElement element = document.Root.Element("OtherParams");
                StartMeasureAddr = (ushort)ConvertFuncs.StrToShort(element.Attribute("StartMeasureAddr").Value.ToString());
                EventCodeAddr = (ushort)ConvertFuncs.StrToShort(element.Attribute("EventCodeAddr").Value.ToString());
                EventTimeAddr = (ushort)ConvertFuncs.StrToShort(element.Attribute("EventTimeAddr").Value.ToString());
                EventBlockCount = (ushort)ConvertFuncs.StrToShort(element.Attribute("EventBlockCount").Value.ToString());
                LoadEventAddr = (ushort)ConvertFuncs.StrToShort(element.Attribute("LoadEventAddr").Value.ToString());
                LoadEventDataAddr = (ushort)ConvertFuncs.StrToShort(element.Attribute("LoadEventDataAddr").Value.ToString());
                EventCount = (ushort)ConvertFuncs.StrToShort(element.Attribute("EventCount").Value.ToString());
             }
            catch
            {
                //eventCount = 0;
                throw new Exception("Errors in part OtherParams of xml file!");
            }

            XElement otherelements = document.Root.Element("OtherParams");

            if (otherelements.Attribute("EnaDigits") == null)
                EnaDigits = false;
            else
                EnaDigits = otherelements.Attribute("EnaDigits").Value.ToBoolean();


            if (otherelements.Attribute("EnaDirectAccess") == null)
                EnaDirectAccess = false;
            else
                EnaDirectAccess = otherelements.Attribute("EnaDirectAccess").Value.ToBoolean();


            if (otherelements.Attribute("EnaFloatDirectAccess") == null)
                EnaFloatDirectAccess = false;
            else
                EnaFloatDirectAccess = otherelements.Attribute("EnaFloatDirectAccess").Value.ToBoolean();


            if (otherelements.Attribute("EnaScope") == null)
                EnaScope = false;
            else
                EnaScope = otherelements.Attribute("EnaScope").Value.ToBoolean();


            if (otherelements.Attribute("EnaEventLog") == null)
                EnaEventLog = false;
            else
                EnaEventLog = otherelements.Attribute("EnaEventLog").Value.ToBoolean();


            if (otherelements.Attribute("EnaLoadSyms") == null)
                EnaLoadSyms = false;
            else
                EnaLoadSyms = otherelements.Attribute("EnaLoadSyms").Value.ToBoolean();


            if (otherelements.Attribute("EnaJog") == null)
                EnaJog = false;
            else
                EnaJog = otherelements.Attribute("EnaJog").Value.ToBoolean();


            if (otherelements.Attribute("EnaAngle") == null)
                EnaAngle = false;
            else
                EnaAngle = otherelements.Attribute("EnaAngle").Value.ToBoolean();

            if (otherelements.Attribute("EnaForceDig") == null)
                EnaForceDig = false;
            else
                EnaForceDig = otherelements.Attribute("EnaForceDig").Value.ToBoolean();

  

            /*   
                       try
                       {
                           object o = otherelements.Attribute("EnaDigits").Value;
                           EnaDigits = (o != null);
                       }
                       catch
                       {
                           EnaDigits = false;
                       }

                       try
                       {
                           object o = otherelements.Attribute("EnaDirectAccess").Value;
                           EnaDirectAccess = (o != null);
                       }
                       catch
                       {
                           EnaDirectAccess = false;
                       }

                       try
                       {
                           object o = otherelements.Attribute("EnaFloatDirectAccess").Value;
                           EnaFloatDirectAccess = (o != null);
                       }
                       catch
                       {
                           EnaFloatDirectAccess = false;
                       }

                       try
                       {
                           object o = otherelements.Attribute("EnaScope").Value;
                           EnaScope = (o != null);
                       }
                       catch
                       {
                           EnaScope = false;
                       }

                       try
                       {
                           object o = otherelements.Attribute("EnaEventLog").Value;
                           EnaEventLog = (o != null);
                       }
                       catch
                       {
                           EnaEventLog = false;
                       }
                       try
                       {
                           object o = otherelements.Attribute("EnaLoadSyms").Value;
                           EnaLoadSyms = (o != null);
                       }
                       catch
                       {
                           EnaLoadSyms = false;
                       }

               */


            int readyCount = 0;
            try
            {
                XElement element = document.Root.Element("Readys");
                readyCount = Convert.ToInt16(element.Attribute("Count").Value.ToString(), 10);
            }
            catch
            {
                readyCount = 0;
                //throw new Exception("Errors in part Digits of xml file!");
            }


            for (int i = 0; i < readyCount; i++)
            {
                try
                {
                    XElement element = document.Root.Element("Ready" + (i + 1).ToString());
                    WarningParam dp = new WarningParam(element.Attribute("Title").Value.ToString());
                    dp.Titl = element.Attribute("Title").Value;



                    dp.EventPosAddr = (ushort)ConvertFuncs.StrToShort(element.Attribute("Addr").Value.ToString());
                    for (int i2 = 0; i2 < 16; i2++)
                    {
                        dp.Names[i2] = element.Attribute("Line" + (i2).ToString()).Value;
                    }


                    readyParams.Add(dp);
                }
                catch
                {
                    throw new Exception("Errors in part Ready" + (i + 1).ToString() + " of xml file!");
                }
            }


            int warningCount = 0;
            try
            {
                XElement element = document.Root.Element("Warnings");
                warningCount = Convert.ToInt16(element.Attribute("Count").Value.ToString(), 10);
            }
            catch
            {
                warningCount = 0;
                //throw new Exception("Errors in part Digits of xml file!");
            }


            for (int i = 0; i < warningCount; i++)
            {
                try
                {
                    XElement element = document.Root.Element("Warning" + (i + 1).ToString());
                    WarningParam dp = new WarningParam(element.Attribute("Title").Value.ToString());
                    dp.Titl = element.Attribute("Title").Value;
                    


                    dp.EventPosAddr = (ushort)ConvertFuncs.StrToShort(element.Attribute("Addr").Value.ToString());
                    for (int i2 = 0; i2 < 16; i2++)
                    {
                        dp.Names[i2] = element.Attribute("Line" + (i2).ToString()).Value;
                    }


                    warningParams.Add(dp);
                }
                catch
                {
                    throw new Exception("Errors in part Warning" + (i + 1).ToString() + " of xml file!");
                }
            }


            int alarmCount = 0;
            try
            {
                XElement element = document.Root.Element("Alarms");
                alarmCount = Convert.ToInt16(element.Attribute("Count").Value.ToString(), 10);
            }
            catch
            {
                alarmCount = 0;
                //throw new Exception("Errors in part Digits of xml file!");
            }


            for (int i = 0; i < alarmCount; i++)
            {
                try
                {
                    XElement element = document.Root.Element("Alarm" + (i + 1).ToString());
                    WarningParam dp = new WarningParam(element.Attribute("Title").Value.ToString());
                    dp.Titl = element.Attribute("Title").Value;

                    dp.EventPosAddr = (ushort)ConvertFuncs.StrToShort(element.Attribute("Addr").Value.ToString());
                    for (int i2 = 0; i2 < 16; i2++)
                    {
                        dp.Names[i2] = element.Attribute("Line" + (i2).ToString()).Value;
                    }


                    alarmParams.Add(dp);
                }
                catch
                {
                    throw new Exception("Errors in part Alarm" + (i + 1).ToString() + " of xml file!");
                }
            }




            try
            {
                XElement element = document.Root.Element("TimeSettings");
                timeConfig = new TimeConfig(element);
            }

            catch
            {
                throw new Exception("Errors in part TimeSettings of xml file!");
            }
        }


    }
}
