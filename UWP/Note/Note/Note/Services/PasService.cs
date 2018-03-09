using Note.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Note.Services
{
    public class PasService : IPasService
    {
        #region VAR 

        public bool isOpen { get; private set; } = false;
        public bool havePas 
        {
            get 
            {
                if (PasHesh.Length > 0)
                    return true;
                return false;
            }
        }

        private string PasHesh = Settings.HashPas;

        #endregion

        public bool GetNewPas(string newPas, string oldPas = "")
        {
            if (Open(oldPas))
            {
                Settings.HashPas = GetHesh(newPas); 
                return true;
            }
            return false;
        }

        public bool Open(string pas)
        {
            if (PasHesh == GetHesh(pas))
                return true;
            return false;
        }

        private static string GetHesh(string pas)
        {
            return pas;
        }

        public void AddPas(string pas)
        {
            PasHesh = GetHesh(pas);
        }
    }
}
