using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Note.Services;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;

namespace Note.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        #region VAR

        private ISaveService saveService;
        private IPasService pasService;
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

        public MainPageViewModel(IPasService pasService, INavigationService navigationService, ISaveService saveService, IPageDialogService pageDialogService) 
            : base (navigationService)
        {
            this.pasService = pasService;
            this.saveService = saveService;
            this.pageDialogService = pageDialogService;

            if (pasService.isOpen)
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
            if (pasService.isOpen)
                EditorText = saveService.GetText();
        }
        private async void SaveExecuted()
        {
            if (pasService.isOpen)
            {
                saveService.Save(_editorText);
                await pageDialogService.DisplayAlertAsync("Save", "Текст успішно збережено", "Ok");
            }
            else
                await pageDialogService.DisplayAlertAsync("Save", "Текст не може зберігатися", "Ok");
        }

       
    }
}
