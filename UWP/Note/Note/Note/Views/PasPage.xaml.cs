using FFImageLoading.Forms;
using System;
using Xamarin.Forms;

namespace Note.Views
{
    public partial class PasPage : ContentPage
    {
        public PasPage()
        {
            InitializeComponent();

            var GooglePlusLogo = new CachedImage();
            TapGestureRecognizer TappedRecognizer = new TapGestureRecognizer();
            TappedRecognizer.Tapped += GPlusTapped;
            GooglePlusLogo.GestureRecognizers.Add(TappedRecognizer);

            var TwitterLogo = new CachedImage();
            TapGestureRecognizer TappedRecognizerTwit = new TapGestureRecognizer();
            TappedRecognizerTwit.Tapped += GPlusTapped;
            TwitterLogo.GestureRecognizers.Add(TappedRecognizerTwit);

            var MicrosoftLogo = new CachedImage();
            TapGestureRecognizer TappedRecognizerMicro = new TapGestureRecognizer();
            TappedRecognizerMicro.Tapped += GPlusTapped;
            MicrosoftLogo.GestureRecognizers.Add(TappedRecognizerMicro);


            var OutlookLogo = new CachedImage();
            TapGestureRecognizer TappedRecognizerOut = new TapGestureRecognizer();
            TappedRecognizerOut.Tapped += GPlusTapped;
            MicrosoftLogo.GestureRecognizers.Add(TappedRecognizerOut);


            if (Device.RuntimePlatform == Device.Android)
            {
                GooglePlusLogo.Source = ImageSource.FromResource("Note.Images.google-plus.png");
                TwitterLogo.Source = ImageSource.FromResource("Note.Images.twitter.png");
                MicrosoftLogo.Source = ImageSource.FromResource("Note.Images.microsoft.png");
                OutlookLogo.Source = ImageSource.FromResource("Note.Images.outlook.png");
            }
            else
            {
                GooglePlusLogo.Source = @"https://fthmb.tqn.com/S1PE2uEKs8bSgP1k-yLboL0ilQ0=/768x0/filters:no_upscale()/google-plus-57d9e4d53df78c9cceedc5e1.png";
                TwitterLogo.Source = @"http://pngimg.com/uploads/twitter/twitter_PNG29.png";
                MicrosoftLogo.Source = @"http://www.pngmart.com/files/4/Microsoft-Logo-PNG-HD.png";
                OutlookLogo.Source = @"https://upload.wikimedia.org/wikipedia/commons/thumb/4/48/Outlook.com_icon.svg/594px-Outlook.com_icon.svg.png";
            }

            SocialPanel.Children.Add(GooglePlusLogo, 1, 0);
            SocialPanel.Children.Add(TwitterLogo, 3, 0);
            SocialPanel.Children.Add(MicrosoftLogo, 5, 0);
            SocialPanel.Children.Add(OutlookLogo, 7, 0);
        }

        private void GPlusTapped(object sender, EventArgs e)
        {
        }
    }
}
