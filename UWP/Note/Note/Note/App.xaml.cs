using Prism;
using Prism.Ioc;
using Note.ViewModels;
using Note.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.Autofac;
using Note.Services;
using System;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Note
{
    public partial class App : PrismApplication
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            await NavigationService.NavigateAsync(new Uri("NoteTabPage", UriKind.Relative));           
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage>("MainPage");
            containerRegistry.RegisterForNavigation<PasPage>("PasPage");
            containerRegistry.RegisterForNavigation<NoteTabPage>("NoteTabPage");

            containerRegistry.RegisterSingleton<ISaveService, SaveService>();
            containerRegistry.RegisterSingleton<IUserService, UserService>();
            containerRegistry.RegisterForNavigation<NoteTabPage>();
        }
    }
}
