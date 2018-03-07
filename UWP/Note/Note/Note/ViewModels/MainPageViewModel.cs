using Note.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Note.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        #region VAR

        private ISaveService saveService;
        private IPageDialogService pageDialogService;

        private string _editorText;
        public string EditorText {
            get { return _editorText; }
            set { SetProperty(ref _editorText, value); }
        }

        public DelegateCommand SaveCommand { get; }

        #endregion

        #region CTOR

        public MainPageViewModel(INavigationService navigationService, ISaveService saveService, IPageDialogService pageDialogService) 
            : base (navigationService)
        {
            this.saveService = saveService;
            this.pageDialogService = pageDialogService;

            Title = "ChIt Note";
            SaveCommand = new DelegateCommand(SaveExecuted)
                .ObservesProperty(() => EditorText);

        }
        #endregion

        private async void SaveExecuted()
        {
            await saveService.Save(_editorText);
            await pageDialogService.DisplayAlertAsync("Save","Текст успішно збережено","Ok");
        }

       
    }
}
