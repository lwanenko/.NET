namespace Note.Services
{
    public interface IUserService
    {
        bool IsOpen { get; }

        bool HavePas { get;  }

        bool NewPas( string newPas, string oldPas );

        void AddPas(string pas);

        bool OpenNotes(string pas);

        void CloseNotes();
    }
}
