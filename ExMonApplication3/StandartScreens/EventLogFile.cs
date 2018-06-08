using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsStructs;
using FormatsConvert;
using System.Xml;
using System.IO;
using TextLibrary;

namespace StandartScreens
{
    public class EventLogFile
    {
        SystemConfiguration systemConfiguration;
        List<ushort[]> eventLogData;
        AppTexts appTexts;

        public EventLogFile(SystemConfiguration SystemConfiguration, AppTexts AppTexts,List<ushort[]> EventLogData)
        {
            eventLogData = EventLogData;
            systemConfiguration = SystemConfiguration;
            appTexts = AppTexts;
        }

        bool CheckSystemConfiguration()
        {
            return true;
        }

        public void CreateEventlogXMLFile(string FileName)
        {
            XmlDocument document;
            XmlNode element;
            XmlAttribute attribute;
            string str;

            if (!CheckSystemConfiguration())
            {
                throw new Exception("Invalid Format!");
            }

            #region CreateFile
            try
            {
                XmlTextWriter textWritter = new XmlTextWriter(FileName, Encoding.UTF8);
                textWritter.WriteStartDocument();
                textWritter.WriteStartElement("Eventlog");
                textWritter.WriteEndElement();
                textWritter.Close();
            }
            catch
            {
                throw new Exception(appTexts.ParameterName(92));
            }

            document = new XmlDocument();
            try
            {
                document.Load(FileName);
            }
            catch
            {
                throw new Exception(appTexts.ParameterName(92));
            }

            #endregion

            #region EventLogSetup
                element = document.CreateElement("EventLogSetup");
                document.DocumentElement.AppendChild(element); // указываем родителя

                attribute = document.CreateAttribute("EventCount"); // создаём атрибут
                attribute.Value = systemConfiguration.EventCount.ToString();
                element.Attributes.Append(attribute); // добавляем атрибут
            #endregion

            for (int eventIndex = 0; eventIndex < systemConfiguration.EventCount; eventIndex++)
            {
                element = document.CreateElement("Event"+eventIndex.ToString());
                document.DocumentElement.AppendChild(element);
                ushort[] eventLine = eventLogData[eventIndex];
                
                #region EventType
                    str = "0x" + eventLine[systemConfiguration.EventCodeAddr].ToString("X4");
                    attribute = document.CreateAttribute("Type"); // создаём атрибут
                    try
                    {
                        str = systemConfiguration.EventCodes[str].ToString();
                    }
                    catch
                    {
                        str = "Нет данных";
                    }
                    attribute.Value = str;
                    element.Attributes.Append(attribute); // добавляем атрибут  
                #endregion

                #region Time

                string strtt = "";
                    int ii = systemConfiguration.EventTimeAddr;
                    strtt = TimeConfig.ExtractTimeFromArray(eventLine, systemConfiguration.TimeConfig, ii);
//                    strtt = strtt + (eventLine[ii+2] & 0x00FF).ToString("X2") + ":";
//                    strtt = strtt + (eventLine[ii + 1] & 0x00FF).ToString("X2") + ":" + (eventLine[ii + 0] & 0x00FF).ToString("X2") + " ";

//                    strtt = strtt + (eventLine[ii + 4] & 0x00FF).ToString("X2") + "/" + (eventLine[ii + 5] & 0x001F).ToString("X2") + "/";
 //                   strtt = strtt + "20" + (eventLine[ii + 6] & 0x00FF).ToString("X2");

                    attribute = document.CreateAttribute("Time"); // создаём атрибут
                    attribute.Value = strtt;
                    element.Attributes.Append(attribute); // добавляем атрибут  

                #endregion

                #region MeasureParams
                    attribute = document.CreateAttribute("MeasureCount"); // создаём атрибут
                    attribute.Value = systemConfiguration.MeasureParams.Count.ToString();
                    element.Attributes.Append(attribute); // добавляем атрибут   

                    for (int i = 0; i < systemConfiguration.MeasureParams.Count; i++)
                    {
                        attribute = document.CreateAttribute("MeasureName" + i.ToString()); // создаём атрибут
                        attribute.Value = systemConfiguration.MeasureParams[i].ParameterName;
                        element.Attributes.Append(attribute); // добавляем атрибут   

                        ushort u = eventLine[systemConfiguration.MeasureParams[i].Addr];
                        string d = u.ToFormatStr(systemConfiguration.MeasureParams[i].Format);
                        attribute = document.CreateAttribute("Measure"+i.ToString()); // создаём атрибут
                        attribute.Value = d;
                        element.Attributes.Append(attribute); // добавляем атрибут   
                    }

                #endregion

                #region digInputs
                    int digInCount = 0;
                    foreach (DigitPlate digitPlate in systemConfiguration.DigitPlates)
                    {
                        if (digitPlate.DigitType == DigitType.DigInput)
                        {
                            ushort u = eventLine[digitPlate.EventStructAddr];
                            ushort mask = digitPlate.UseMask;
                           
                            for (int i = 0; i < 16; i++)
                            {
                                if (ConvertFuncs.GetBit(mask,i))
                                {
                                    attribute = document.CreateAttribute("DigInName" + digInCount.ToString()); // создаём атрибут
                                    attribute.Value = digitPlate.DigitNames[i];
                                    element.Attributes.Append(attribute); // добавляем атрибут   

                                    attribute = document.CreateAttribute("DigInValue" + digInCount.ToString()); // создаём атрибут
                                    attribute.Value = ConvertFuncs.GetBit(u, i).ToString();
                                    element.Attributes.Append(attribute); // добавляем атрибут  
                                    digInCount++;
                                }
                                
                            }

                        }
                    }

                    attribute = document.CreateAttribute("DigInCount"); // создаём атрибут
                    attribute.Value = digInCount.ToString();
                    element.Attributes.Append(attribute); // добавляем атрибут  


                #endregion

                #region digOutputs
                    int digOutCount = 0;
                    foreach (DigitPlate digitPlate in systemConfiguration.DigitPlates)
                    {
                        if (digitPlate.DigitType == DigitType.DigOutput)
                        {
                            ushort u = eventLine[digitPlate.EventStructAddr];
                            ushort mask = digitPlate.UseMask;

                            for (int i = 0; i < 16; i++)
                            {
                                if (ConvertFuncs.GetBit(mask, i))
                                {
                                    attribute = document.CreateAttribute("DigOutName" + digOutCount.ToString()); // создаём атрибут
                                    attribute.Value = digitPlate.DigitNames[i];
                                    element.Attributes.Append(attribute); // добавляем атрибут   

                                    attribute = document.CreateAttribute("DigOutValue" + digOutCount.ToString()); // создаём атрибут
                                    attribute.Value = ConvertFuncs.GetBit(u, i).ToString();
                                    element.Attributes.Append(attribute); // добавляем атрибут  
                                    digOutCount++;
                                }

                            }

                        }
                    }

                    attribute = document.CreateAttribute("DigOutCount"); // создаём атрибут
                    attribute.Value = digOutCount.ToString();
                    element.Attributes.Append(attribute); // добавляем атрибут  


                 #endregion

                #region Warnings
                    int warnsCount = 0;
                    foreach (WarningParam wp in systemConfiguration.WarningParams)
                    {
                        ushort u = eventLine[wp.EventPosAddr];
                       // System.Windows.Forms.MessageBox.Show(wp.Titl+":  0x"+u.ToString("X4"));
                        for (int i = 0; i < 16; i++)
                        {
                            if (ConvertFuncs.GetBit(u, i))
                            {
                                attribute = document.CreateAttribute("WarningName" + warnsCount.ToString()); // создаём атрибут
                                attribute.Value = wp.Names[i];
                                element.Attributes.Append(attribute); // добавляем атрибут   
                                warnsCount++;
                            }
                            
                        }
                    }

                    attribute = document.CreateAttribute("WarningsCount"); // создаём атрибут
                    attribute.Value = warnsCount.ToString();
                    element.Attributes.Append(attribute); // добавляем атрибут  

                #endregion

                #region Alarms
                    int alarmsCount = 0;
                    foreach (WarningParam wp in systemConfiguration.AlarmParams)
                    {
                        ushort u = eventLine[wp.EventPosAddr];
                        for (int i = 0; i < 16; i++)
                        {
                            if (ConvertFuncs.GetBit(u, i))
                            {
                                attribute = document.CreateAttribute("AlarmName" + alarmsCount.ToString()); // создаём атрибут
                                attribute.Value = wp.Names[i];
                                element.Attributes.Append(attribute); // добавляем атрибут   
                                alarmsCount++;
                            }
                            
                        }
                    }

                    attribute = document.CreateAttribute("AlarmsCount"); // создаём атрибут
                    attribute.Value = alarmsCount.ToString();
                    element.Attributes.Append(attribute); // добавляем атрибут  

                #endregion
            }

            try
            {
                document.Save(FileName);
            }
            catch
            {
                throw new Exception(appTexts.ParameterName(92));
            }

        }

    }
}
