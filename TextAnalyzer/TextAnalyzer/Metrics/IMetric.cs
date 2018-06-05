using System;
using System.Collections.Generic;
using System.Text;
using TextAnalyzer.Services;

namespace TextAnalyzer.Metrics
{
    interface IMetric
    {
        int GetValue(string text);      
    }
}
