using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsStructs
{
    public class DigitPlate
    {
        string titl = "";
        public string Titl
        {
            get { return titl; }
            set { titl = value; }
        }

        ushort startAddr = 0x0000;
        public ushort StartAddr
        {
            get
            {
                return startAddr;
            }

            set
            {
                startAddr = value;
            }
        }

        ushort eventStructAddr = 0x0000;
        public ushort EventStructAddr
        {
            get { return eventStructAddr; }
            set { eventStructAddr = value; }
        }

        ushort useMask = 0xFFFF;
        public ushort UseMask
        {
            get { return useMask; }
            set { useMask = value; }
        }

        string[] digitNames = new string[16];
        public string[] DigitNames
        {
            get { return digitNames; }
            set { digitNames = value; }
        }

        DigitType digitType = DigitType.DigInput;
        public DigitType DigitType
        {
            get { return digitType; }
            set { digitType = value; }
        }

        bool invert = false;
        public bool Invert
        {
            get { return invert; }
            set { invert = value; }
        }


        public DigitPlate(string DigitName)
        {
            titl = DigitName;
        }

        public DigitPlate()
        {
            
        }

        public DigitPlate Copy()
        {
            DigitPlate dp = new DigitPlate();
            dp.Titl = this.Titl;
            dp.StartAddr = this.startAddr;
            dp.EventStructAddr = this.EventStructAddr;
            dp.UseMask = this.UseMask;
            dp.DigitNames = this.DigitNames;
            dp.DigitType = this.digitType;
            dp.Invert = this.invert;
            return dp;
        }
    }
}
