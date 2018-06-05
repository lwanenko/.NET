using System;
using System.Collections.Generic;
using System.Text;
using TextAnalyzer.Services;

namespace TextAnalyzer.Metrics
{
    //кількість слів 
    public class Metric1 : IMetric
    {
        public int GetValue (string text)
        {
            var service = new WordsService();
            service.Parce(text);
            return service.Words.Count;
        }
    }
}
