using System;
using System.Collections.Generic;
using System.Text;
using TextAnalyzer.Services;

namespace TextAnalyzer.Metrics
{
    interface IMetric
    {
        ITextService Service { get; }

        int Value { get; }

    }
}
