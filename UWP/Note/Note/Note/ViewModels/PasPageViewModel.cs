using Note.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Note.ViewModels
{
	public class PasPageViewModel : ViewModelBase
	{
        private readonly IPasService pasService;
        private ISaveService saveService;
        private readonly IPageDialogService pageDialogService;

        private string _pasLabel;
        public string PasLabel {
            get { return _pasLabel; }
            set { SetProperty(ref _pasLabel, value); }
        }


        public DelegateCommand UnLockCommand { get; private set; }
        public DelegateCommand AddPasCommand { get; private set; }

        public PasPageViewModel(IPasService pasService, INavigationService navigationService, ISaveService saveService, IPageDialogService pageDialogService)
            : base(navigationService)
        {
            this.pasService = pasService;
            this.saveService = saveService;
            this.pageDialogService = pageDialogService;
            UnLockCommand = new DelegateCommand(UnLockExecuted);
            AddPasCommand = new DelegateCommand(AddPasExecuted);
        }

        private async void AddPasExecuted()
        {
            pasService.AddPas(PasLabel);
            await pageDialogService.DisplayAlertAsync("", "Password Add", "Ok");
        }

        private async void UnLockExecuted()
        {
            
            if (pasService.Open(PasLabel))
                await NavigationService.NavigateAsync("NavigationPage/MainPage");
            else
                await pageDialogService.DisplayAlertAsync("Erorr", "Fail Password", "Ok");
        }
    }
}
