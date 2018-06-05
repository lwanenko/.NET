using System;
using TextAnalyzer.Metrics;
using TextAnalyzer.Services;

namespace TextAnalyzer
{
    class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var inputText = Input(@"C:\Users\HP\Source\Repos\.NET\TextAnalyzer\TextAnalyzer\Text.txt");

            var metric1 = new Metric1();
            Console.WriteLine(  metric1.GetValue(inputText) );

            var metric2 = new Metric2();
            Console.WriteLine(  metric2.GetValue(inputText) );

            Console.ReadKey();
        }

        private static string Input(string path)
        {      
            return System.IO.File.ReadAllText(path);
        }
    }
}
