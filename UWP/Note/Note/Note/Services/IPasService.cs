namespace Note.Services
{
    public interface IPasService
    {
        bool IsOpen { get; }

        bool HavePas { get;  }

        bool NewPas( string newPas, string oldPas );

        void AddPas(string pas);

        bool Open(string pas);

        void Close();
    }
}
