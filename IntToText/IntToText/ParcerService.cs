using IntToText.Models;
using System.Collections.Generic;
using System.Text;

namespace IntToText
{
    public class ParcerService
    {
        public ParcerService(string val)
        {
            NumberVal = val;
        }

        public string NumberVal { get; set; } 

        public string Result 
        {
            get 
            {
                string result = "";
                foreach (var grade in Parcing())
                {
                    result = result + " " + grade.ReturnText();
                }

                foreach (var rule in Rules)
                    if(result.Contains(rule.Item1))
                        result = result.Replace(rule.Item1,rule.Item2);
                return result;
            }
        }

        private List<Grade> Parcing( bool revers = true )
        {
            var list = new List<Grade>();
            bool isFirst = true;
            int i = NumberVal.Length -1;
            int GradeNum = 0;
            while (i >= 0)
            {
                if (isFirst)
                {
                    list.Add(new Grade(NumberVal.Substring(i - 1, 2), DataGrade[GradeNum]));
                    isFirst = false;
                }
                else if (i > 2)
                    list.Add(new Grade(NumberVal.Substring(i - 2, 3), DataGrade[GradeNum]));
                else
                    list.Add(new Grade(NumberVal.Substring(0,i+1), DataGrade[GradeNum], true));
                i -= 3;
                GradeNum++;
            }
            if (revers) list.Reverse();
            return list; 
        }

        public static Dictionary<int, (string, string)> DataGrade = new Dictionary<int, (string, string)>();

        public static List<(string, string)> Rules = new List<(string, string)>();
    }
}
