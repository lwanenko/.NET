﻿using Note.Services;
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
        private readonly IPasService pasService;
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

        public DelegateCommand ButtonCommand { get; set; }

        public PasPageViewModel(IPasService pasService,
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
            if (pasService.Open(PasLabel))
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
