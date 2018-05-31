using System;
using System.Collections.Generic;
using System.Text;

namespace IntToText.Models
{
    public class Grade
    {
        public Grade(string value, (string, string) names, bool isFirst = false)
        {
            Value = value;
            this.nameForOne  = names.Item1;
            this.nameForMany = names.Item2;
            IsFirst = isFirst;
        }

        public string Value { get; set; }

        public static Dictionary<string, string> Data = new Dictionary<string, string>();
        public static Dictionary<string, string> DataForFirst = new Dictionary<string, string>();

    private bool IsFirst;

        private string nameForOne;
        private string nameForMany;
        public string Name 
        {
            get 
            {
                if (Value[Value.Length-1] == '1')
                    return nameForOne;
                return nameForMany;
            }
        }

        private bool CheckValInData(ref string @return, string val)
        {
            if(IsFirst)
                if (DataForFirst.ContainsKey(val))
                {
                    @return = @return + " " + DataForFirst[val];
                    return false;
                }
            if (Data.ContainsKey(val))
            {
                @return = @return + " " + Data[val];
                return false;
            }
            return true;
        }

        private string ZeroString(int length)
        {
            StringBuilder @return = new StringBuilder();
            for (int i = 0; i < length; i++)
                @return.Append("0");
            return @return.ToString();
        }

        public string ReturnText(bool firstName = false)
        {
            
            var returnString = "";
            if(firstName) returnString += Name;

            var val = Value;
            while (CheckValInData(ref returnString, val))
            {
                string majorGrade = Convert.ToString(val[0]) + ZeroString(val.Length-1);
                CheckValInData(ref returnString, majorGrade);

                if (val.Length == 1)
                    return "";// 000
                val = val.Substring(1, val.Length - 1);
            } 
                
            if (!firstName) returnString = returnString + " " + Name;

            return returnString;
        }       
    }
}
