using Xamarin.Forms;

namespace Note.Views
{
    public partial class PasPage : ContentPage
    {
        public PasPage()
        {
            InitializeComponent();
            var icon = new FileImageSource();
            icon.File = "png/locked.png";
            Unlock.Icon  = icon;
        }
    }
}
