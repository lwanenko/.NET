using System;
using System.Collections.Generic;
using System.Text;

namespace TextAnalyzer.Services
{
    public interface ITextService
    {   
        bool IsInit { get; set; }
        bool Parce(string text);      
    }
}
