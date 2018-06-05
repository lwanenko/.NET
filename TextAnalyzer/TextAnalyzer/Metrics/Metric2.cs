using System;
using System.Collections.Generic;
using System.Text;
using TextAnalyzer.Services;

namespace TextAnalyzer.Metrics
{   
    // кількість входжень найпопулярнішої в тексті літери
    public class Metric2 : IMetric
    {
        private TrigramService service;
        private Dictionary<char, int> data;

        public int GetValue(string text)
        {
            service = new TrigramService();
            service.Parce(text);
           
            data = new Dictionary<char, int>();

            Add(text[0], 2);
            Add(text[1], 1);

            foreach (var cur in service.Data)
            {
                Add(cur.Key[0], cur.Value);
                Add(cur.Key[1], cur.Value);
                Add(cur.Key[2], cur.Value);
            }
            Add(text[text.Length-2], 1);
            Add(text[text.Length -1], 2);

            return GetMax();
        }

        private void Add(char c, int i)
        {
            if (data.ContainsKey(c))
                data[c] += i;
            else
                data.Add(c, 1);
        }

        private int GetMax()
        {
            int max = 0;
            bool first = true;
            foreach (var cur in data)
            {
                if (first)
                    max = cur.Value;
                else if (max < cur.Value)
                    max = cur.Value;
            }
            return max;
        }
    }
}
