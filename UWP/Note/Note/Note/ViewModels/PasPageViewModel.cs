using Note.Models;
using Note.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Note.ViewModels
{
	public class PasPageViewModel : ViewModelBase
	{
        private readonly IUserService pasService;
        private ISaveService saveService;
        private readonly IPageDialogService pageDialogService;

        private string _pasLabel;
        public string PasLabel {
            get { return _pasLabel; }
            set { SetProperty(ref _pasLabel, value); }
        }

        private string _butText;
        public string ButtonText {
            get { return _butText; }
            set { SetProperty(ref _butText, value); }
        }

        private User user = new User();
        public string UserName 
        {
            get { return user.Name; }
            set { SetProperty(ref user.Name, value); }
        }
        public string AvatarUrl 
        {
            get { return user.AvatarUrl; }
            set { SetProperty(ref user.AvatarUrl, value); }
        }

        public DelegateCommand ButtonCommand { get; set; }

        public PasPageViewModel(IUserService pasService,
                                INavigationService navigationService, 
                                ISaveService saveService, 
                                IPageDialogService pageDialogService): base(navigationService)
        {
            this.pasService = pasService;
            this.saveService = saveService;
            this.pageDialogService = pageDialogService;

            ButtonCommand = new DelegateCommand(ButtonExecuted);
            if (pasService.HavePas)        
                ButtonText = "Unlock";
            else
                ButtonText = "Add Password"; 
        }

        private void ButtonExecuted()
        {
            if (pasService.HavePas)
                UnLockExecuted();
            else
                AddPasExecuted();
        }

        private async void AddPasExecuted()
        {
            if ( PasLabel.Length != 0)
            {
                pasService.AddPas(PasLabel);
                ButtonText = "Unlock";
                await pageDialogService.DisplayAlertAsync("", "Password Add", "OK");
            }
            else 
                await pageDialogService.DisplayAlertAsync("Ooooh", "Error","OK");
        }

        private async void UnLockExecuted()
        {
            if (pasService.OpenNotes(PasLabel))
            {
                PasLabel = "";
                await NavigationService.GoBackAsync();
                await NavigationService.NavigateAsync("MainPage");

            }
            else
                await pageDialogService.DisplayAlertAsync("Erorr", "Fail Password", "Ok");
        }
    }
}
