using System;
using System.Collections.Generic;
using System.Text;

namespace Note.Services
{
    public class PasService : IPasService
    {
        public bool isOpen { get; set; }

        public bool GetNewPas(string newPas, string oldPas = "")
        {
            throw new NotImplementedException();
        }

        public bool Open(string pas)
        {
            throw new NotImplementedException();
        }
    }
}
