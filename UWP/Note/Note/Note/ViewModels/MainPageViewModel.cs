using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Note.Services;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Forms;

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
            set 
            {
                SetProperty(ref _editorText, value);
                SetProperty(ref _length, value.Length);
            }
        }

        private int _length;
        public  string TextLength {
            get { return "Length: " + _length;}
            
        } 

        public DelegateCommand SaveCommand { get; }
        public DelegateCommand BackCommand { get; }
        public DelegateCommand LockCommand { get; }
        #endregion

        #region CTOR

        public MainPageViewModel(IPasService        pasService,
                                 INavigationService navigationService,
                                 ISaveService       saveService,
                                 IPageDialogService pageDialogService) : base (navigationService)
        {
            this.pasService = pasService;
            this.saveService = saveService;
            this.pageDialogService = pageDialogService;

            if (pasService.IsOpen)
                EditorText = saveService.GetText();
                
            BackCommand = new DelegateCommand(BackExecuted)
                .ObservesProperty(() => EditorText);
            SaveCommand = new DelegateCommand(SaveExecuted)
                .ObservesProperty(() => EditorText);
            LockCommand = new DelegateCommand(LockExecuted);
        }

        #endregion

        private async void LockExecuted()
        {
            pasService.Close();            
            await NavigationService.GoBackAsync();
            await NavigationService.NavigateAsync(new Uri("PasPage", UriKind.Relative));
        }

        private void BackExecuted()
        {
            if (pasService.IsOpen)
                EditorText = saveService.GetText();
        }

        private async void SaveExecuted()
        {
            if (pasService.IsOpen)
            {
                saveService.Save(_editorText);
                await pageDialogService.DisplayAlertAsync("Save", "Текст успішно збережено", "Ok");
            }
            else
                await pageDialogService.DisplayAlertAsync("Save", "Текст не може зберігатися", "Ok");
        }
       
    }
}
