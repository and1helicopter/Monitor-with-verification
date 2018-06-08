using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FormatsConvert;

namespace WindowsStructs
{
    public class MeasureParam
    {
        string parameterName = "";
        public string ParameterName
        {
            get { return parameterName; }
            set { parameterName = value; }
        }

        ushort addr = 0;
        public ushort Addr
        {
            get { return addr; }
            set { addr = value; }
        }

        ConvertFormats format = ConvertFormats.Percent;
        public ConvertFormats Format
        {
            get { return format; }
            set { format = value; }
        }

        public MeasureParam(string ParameterName, string Addr, string Format)
        {
            this.ParameterName = ParameterName;
            
            try
            {
                addr = (ushort)ConvertFuncs.StrToShort(Addr);
            }
            catch
            {
                addr = 0;
            }


            try
            {
                format = Format.ToConvertFormats();
            }
            catch
            {
                format = ConvertFormats.Percent;
            }


        }
        public MeasureParam(string ParameterName, ushort Addr, ConvertFormats Format)
        {
            this.ParameterName = ParameterName;
            this.addr = Addr;
            this.format = Format;
        }
    }
}
