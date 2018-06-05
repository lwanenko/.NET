using System;
using System.Collections.Generic;
using System.Text;

namespace TextAnalyzer.Services
{
    public class WordsService : ITextService
    {
        #region VAR 
        public bool IsInit { get; set; }

        public Dictionary<string, int> Words { get; set; }
        #endregion

        public bool Parce(string text)
        {
            try
            {
                if (!IsInit)
                {
                    Words = new Dictionary<string, int>();
                    int lenght = 0;
                    int cur = -1;
                    for (int i = 0; i < text.Length; i++)
                    {
                        if (cur == -1 && IsSymbol(text[i]))
                            cur = i;
                        else if (cur == -1)
                            continue;
                        else if (IsSymbol(text[i]))
                            lenght++;
                        else
                        {
                            var key = text.Substring(cur, lenght);

                            if (Words.ContainsKey(key))
                                Words[key]++;
                            else
                                Words.Add(key, 1);
                            cur = -1;
                            lenght = 0;
                        }
                        
                    }

                    if (cur != -1)
                    {
                        var key = text.Substring(cur, lenght);

                        if (Words.ContainsKey(key))
                            Words[key]++;
                        else
                            Words.Add(key, 1);
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }  
        }

        bool IsSymbol(char cur)
        {
            switch (cur)
            {
                case 'q':
                    return true;
                case 'w':
                    return true;
                case 'e':
                    return true;
                case 'r':
                    return true;
                case 't':
                    return true;
                case 'y':
                    return true;
                case 'u':
                    return true;
                case 'i':
                    return true;
                case 'o':
                    return true;
                case 'p':
                    return true;
                case 'a':
                    return true;
                case 's':
                    return true;
                case 'd':
                    return true;
                case 'f':
                    return true;
                case 'g':
                    return true;
                case 'h':
                    return true;
                case 'j':
                    return true;
                case 'k':
                    return true;
                case 'l':
                    return true;
                case 'z':
                    return true;
                case 'x':
                    return true;
                case 'c':
                    return true;
                case 'v':
                    return true;
                case 'b':
                    return true;
                case 'n':
                    return true;
                case 'm':
                    return true;
                default:
                    return false;
            }
            }
    }
}
