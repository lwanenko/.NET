using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Note.Services
{
    public interface ISaveService
    {
        Task Save(string text);
    }
}
