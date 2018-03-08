using System.Threading.Tasks;
using Note.Helpers;

namespace Note.Services
{
    public class SaveService : ISaveService
    {
        public string GetText()
        {
            return Settings.Text;
        }

        public void Save(string text)
        {
            Settings.Text = text;
        }
    }
}
