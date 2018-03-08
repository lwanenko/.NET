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
        public DelegateCommand BackCommand { get; }
        #endregion

        #region CTOR

        public MainPageViewModel(INavigationService navigationService, ISaveService saveService, IPageDialogService pageDialogService) 
            : base (navigationService)
        {
            this.saveService = saveService;
            this.pageDialogService = pageDialogService;
            EditorText = saveService.GetText();
            Title = "ChIt Note";
            BackCommand = new DelegateCommand(BackExecuted)
                .ObservesProperty(() => EditorText);
            SaveCommand = new DelegateCommand(SaveExecuted)
                .ObservesProperty(() => EditorText);

        }
        
        #endregion

        private void BackExecuted()
        {
           EditorText = saveService.GetText();
        }
        private async void SaveExecuted()
        {
            saveService.Save(_editorText);
            await pageDialogService.DisplayAlertAsync("Save","Текст успішно збережено","Ok");
        }

       
    }
}
