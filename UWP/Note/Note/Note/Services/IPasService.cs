namespace Note.Services
{
    interface IPasService
    {
        bool isOpen { get; set; }
        bool GetNewPas( string newPas, string oldPas = "");
        bool Open(string pas);
    }
}
