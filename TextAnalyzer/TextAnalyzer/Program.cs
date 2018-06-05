using System;
using TextAnalyzer.Services;

namespace TextAnalyzer
{
    class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var inputText = Input(@"C:\Users\HP\Source\Repos\.NET\TextAnalyzer\TextAnalyzer\Text.txt");
            var service = new TrigramService();
            Console.WriteLine(  service.Parce(inputText) );
            Console.ReadKey();
        }

        private static string Input(string path)
        {      
            return System.IO.File.ReadAllText(path);
        }
    }
}
