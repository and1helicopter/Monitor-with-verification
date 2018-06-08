using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace FormatsConvert
{
    public class ParamSet
    {


        public int Offset
        {
            get; set;
        }
        public int Count
        {
            get; set;
        }
        public string Text
        {
            get; set;
        }
        public List<string> Unit
        {
            get; set;
        }
        public double Min
        {
            get; set;
        }
        public double Max
        {
            get; set;
        }
        public List<int> Precision
        {
            get; set;
        }
        public List<ConvertFormats> Format
        {
            get; set;
        }

        public bool Visible
        {
            get; set;
        }

        public ParamSet MinParam
        {
            get; set;
        }
        public ParamSet MaxParam
        {
            get; set;
        }
        public ParamSet SpeedParam
        {
            get; set;
        }
    }

    public class CalibrSet
    {


        public int Offset
        {
            get; set;
        }
        
        public string Text
        {
            get; set;
        }
        public List<string> Unit
        {
            get; set;
        }
        public double Min
        {
            get; set;
        }
        public double Max
        {
            get; set;
        }
        public int Precision
        {
            get; set;
        }

        public bool Visible
        {
            get; set;
        }

        public bool DisZero
        {
            get; set;
        }
        public bool DisDefault
        {
            get; set;
        }
        public bool DisInput
        {
            get; set;
        }
    }

    public class ButtonSet
    {



        public string Text
        {
            get; set;
        }
        public bool Disable
        {
            get; set;
        }

    }
    public class LampSet
    {

        public int Offset
        {
            get; set;
        }
        public int Count
        {
            get; set;
        }

        public string Text
        {
            get; set;
        }
        public Color Col
        {
            get; set;
        }
        public ulong Mask
        {
            get; set;
        }
        public bool Inverted
        {
            get; set;
        }
        public bool Visible
        {
            get; set;
        }
    }
    public class WindowSet
    {

        public ushort Address
        {
            get; set;
        }
        public ushort Count
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }


        public ParamSet[] param
        {
            get; set;
        }
        public ParamSet[] refer
        {
            get; set;
        }
        public ButtonSet[] button
        {
            get; set;
        }

        public LampSet[] lamp
        {
            get; set;
        }

        public string[] label
        {
            get; set;
        }
    }

    public class WindowCalibrSet
    {

        public ushort Address
        {
            get; set;
        }
        public ushort Count
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }

        public ushort ZeroAddress
        {
            get; set;
        }

        public ulong ZeroValue
        {
            get; set;
        }
        public CalibrSet[] param
        {
            get; set;
        }
       
        public ButtonSet[] button
        {
            get; set;
        }

    }

    public class DigitSet
    {

        public ushort Address
        {
            get; set;
        }
        public ushort Count
        {
            get; set;
        }
        public string Name
        {
            get; set;
        }

        public string[] Labels
        {
            get; set;
        }
        
        public ulong Mask
        {
            get; set;
        }
        public bool Inverted
        {
            get; set;
        }
       
    }

    public class DigitsPlate
    {

        public string Name
        {
            get; set;
        }


        public DigitSet DigInputs
        {
            get; set;
        }
        public DigitSet DigOutputs
        {
            get; set;
        }
        
    }

    public class ComPortSet
    {

        public string Name
        {
            get; set;
        }


        public byte Address
        {
            get; set;
        }

        public int Speed
        {
            get; set;
        }

        public System.IO.Ports.Parity Parity
        {
            get; set;
        }

        public System.IO.Ports.StopBits StopBits
        {
            get; set;
        }

    }
}
