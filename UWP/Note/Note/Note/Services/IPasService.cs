namespace Note.Services
{
    public interface IPasService
    {
        bool isOpen { get; }
        bool havePas { get;  }
        bool GetNewPas( string newPas, string oldPas );
        void AddPas(string pas);
        bool Open(string pas);
    }
}
