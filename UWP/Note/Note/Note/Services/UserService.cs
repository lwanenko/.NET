using Note.Helpers;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Note.Services
{
    public class UserService : IUserService
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
            if (OpenNotes(oldPas))
            {
                Settings.HashPas = HashPas(newPas); 
                return true;
            }
            return false;
        }

        public void AddPas(string pas)
        {
            Settings.HashPas = HashPas(pas);
        }

        public bool OpenNotes(string pas)
        {
            if (Settings.HashPas == HashPas(pas))
                IsOpen = true;
            return IsOpen;
        }

        public void CloseNotes()
        {
            IsOpen = false;
        }

       

        #region PRIVATE

        public static string HashPas(string password)
        {
            byte[] salt;
            byte[] buffer2;
            
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
            {
                salt = bytes.Salt;
                buffer2 = bytes.GetBytes(0x20);
            }
            byte[] dst = new byte[0x31];
            Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
            Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);
            return Convert.ToBase64String(dst);
        }

        #endregion

    }
}
