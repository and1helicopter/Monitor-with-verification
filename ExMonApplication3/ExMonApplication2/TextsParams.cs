using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TextLibrary;

namespace ExMonApplication2
{
    public static class TextsParams
    {
        public static ElementsStrings elementStrings = new ElementsStrings("strings.xml");
        public static int Language { get; set; }
        public static string ParameterName(int ParamNum)
        {
            try
            {
                return (elementStrings.Parameters[ParamNum].ParamNames[Language]);
            }
            catch
            {
                return ("Error");
            }
        }

        public static string ParameterNameUpper(int ParamNum)
        {
            try
            {
                string str = elementStrings.Parameters[ParamNum].ParamNames[Language];
                str = str.ToUpper();
                return (str);
            }
            catch
            {
                return ("Error");
            }
        }
        public static string ParameterNameMulty(int ParamNum)
        {
            string str;
            try
            {
                str = elementStrings.Parameters[ParamNum].ParamNames[Language];
            }
            catch
            {
                return ("Error");
            }
            string[] paramListstr;
            char[] delimiterChars = { ' ' };
            paramListstr = str.Split(delimiterChars);
            str = "";
            for (int i = 0; i < paramListstr.Length; i++)
            {
                str = str + paramListstr[i];
                if (i != (paramListstr.Length - 1)) { str = str + "\n"; }
            }
            return str;
        }


        public static List<string> GetListParamNames(int StartIndex, int EndIndex)
        {
            List<string> strs = new List<string>();
            for (int i = StartIndex; i <= EndIndex; i++)
            {
                strs.Add(ParameterName(i));
            }
            return strs;
        }
    }
}
