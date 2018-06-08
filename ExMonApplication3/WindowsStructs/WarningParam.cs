using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsStructs
{
    public class WarningParam :ICloneable
    {
        public WarningParam(string Titl)
        {
            this.Titl = Titl;
        }
        
        ushort eventPosAddr = 0x0000;
        public ushort EventPosAddr
        {
            get { return eventPosAddr; }
            set { eventPosAddr = value; }
        }

        string[] names = new string[16];
        public string[] Names
        {
            get
            {
                return names;
            }
            set
            {
                names = Names;
            }
        }

        string titl = "";

        public string Titl
        {
            get { return titl; }
            set { titl = value; }
        }

        public object Clone()
        {
            WarningParam wp = new WarningParam(this.Titl);
            wp.names = this.names;
            wp.eventPosAddr = this.eventPosAddr;
            return wp;
        }
    }
}
