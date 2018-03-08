namespace Note.Services
{
    public interface ISaveService
    {
        void Save(string text);

        string GetText();
    }
}