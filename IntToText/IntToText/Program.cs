using IntToText.Models;
using System;
using System.Collections.Generic;

namespace IntToText
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Hello World!");

                string line;
                line = Console.ReadLine();
                line = line.Trim();
                if (line.Contains("."))
                    GoToUA();
                else if (line.Contains(","))
                    GoToUA();
                else throw new Exception("error");

                ParcerService service = new ParcerService(line);
                Console.WriteLine(service.Result);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.Read();
        }

        static void GoToUA()
        {
            Dictionary<string, string> Data = new Dictionary<string, string>();
           
            Data.Add("1", "один");
            Data.Add("2", "два");
            Data.Add("3", "три");
            Data.Add("4", "чотири");
            Data.Add("5", "пять");
            Data.Add("6", "шість");
            Data.Add("7", "сім");
            Data.Add("8", "вісім");
            Data.Add("9", "дев'ять");
            Data.Add("10", "десять");
            Data.Add("11", "одинадцять");
            Data.Add("12", "дванадцять");
            Data.Add("13", "тринадцять");
            Data.Add("14", "чотирнадцять");
            Data.Add("15", "п'ятнадцять");
            Data.Add("16", "шістнадцять");
            Data.Add("17", "сімнадцять");
            Data.Add("18", "вісімнадцять");
            Data.Add("19", "девятнадцять");
            Data.Add("20", "двадцять");
            Data.Add("30", "тридцять");
            Data.Add("40", "сорок");
            Data.Add("50", "п'ятдесят");
            Data.Add("60", "шістдесят");
            Data.Add("70", "сімдесят");
            Data.Add("80", "вісімдесят");
            Data.Add("90", "дев'яносто");
            Data.Add("100", "сто");
            Data.Add("200", "двісті");
            Data.Add("300", "триста");
            Data.Add("400", "чотириста");
            Data.Add("500", "п'ятсот");
            Data.Add("600", "шістсот");
            Data.Add("700", "сімсот");
            Data.Add("800", "вісімсот");
            Data.Add("900", "девятсот");

            Grade.Data = Data;

            Dictionary<string, string> DataForFirst = new Dictionary<string, string>();
            DataForFirst.Add("1", "одна");
            DataForFirst.Add("2", "дві");

            Grade.DataForFirst = DataForFirst;

            Dictionary<int, (string, string)> DataGrade = new Dictionary<int, (string, string)>();

            DataGrade.Add(0, ("копійка", "копійок"));
            DataGrade.Add(1, ("гривня", "гривень"));
            DataGrade.Add(2, ("тисяча", "тисяч"));
            DataGrade.Add(3, ("мільйон", "мільйони"));
            DataGrade.Add(4, ("мільярд", "мільярди"));
            DataGrade.Add(5, ("мільярд+", "мільярди+"));
            DataGrade.Add(6, ("мільярд++", "мільярди++"));

            ParcerService.DataGrade = DataGrade;

            List<(string, string)> Rules = new List<(string, string)>();
            Rules.Add(("два гривень","дві гривні"));
            Rules.Add(("два копійок", "дві копійки")); 
            Rules.Add(("два тисяч", "дві тисячі"));
            Rules.Add(("три гривень", "три гривні"));
            Rules.Add(("три копійок", "три копійки"));
            Rules.Add(("три тисяч", "три тисячі"));
            Rules.Add(("чотири гривень", "чотири гривні"));
            Rules.Add(("чотири копійок", "чотири копійки"));
            Rules.Add(("чотири тисяч", "чотири тисячі"));
            //...

            ParcerService.Rules = Rules;
        }

        
    }
}
