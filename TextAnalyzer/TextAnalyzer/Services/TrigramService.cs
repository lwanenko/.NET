using System;
using System.Collections.Generic;
using System.Text;

namespace TextAnalyzer.Services
{
    public class TrigramService : ITextService
    {

        public bool Parce(string text)
        {
            try
            {
                if (!IsInit)
                {
                    Data = new Dictionary<string, int>();
                    for (int i = 0; i < text.Length - 2; i++)
                    {
                        var key = text.Substring(i, 3);
                        if (Data.ContainsKey(key))
                            Data[key]++;
                        else
                            Data.Add(key, 1);
                    }
                }
                IsInit = true;
                return true;
            }
            catch
            {
                return false;
            }
        }

        #region VAR 

        public Dictionary<string, int> Data { get; set; }

        public bool IsInit { get; set; }

        #endregion
    }
}
