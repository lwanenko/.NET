using Note.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Note.Services
{
    public class PasService : IPasService
    {
        #region VAR 

        public bool IsOpen { get; private set; } = false;

        public bool HavePas {
            get {
                if (Settings.HashPas.Length > 0)
                    return true;
                return false;
            }
        }
        #endregion

        public bool NewPas(string newPas, string oldPas = "")
        {
            if (Open(oldPas))
            {
                Settings.HashPas = GetHash(newPas); 
                return true;
            }
            return false;
        }

        public bool Open(string pas)
        {
            if (Settings.HashPas == GetHash(pas))
                IsOpen = true;
            return IsOpen;
        }

        public void Close()
        {
            IsOpen = false;
        }

        public void AddPas(string pas)
        {
            Settings.HashPas = GetHash(pas);
        }

        private static string GetHash(string pas)
        {
            return pas;
        }

        
    }
}
