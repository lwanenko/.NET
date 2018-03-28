using Autofac;
using Autofac.Core;
using Note.ViewModels;
using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Forms;

namespace Note.Views
{
    public partial class NoteTabPage : TabbedPage, INavigatingAware
    {
        IContainer _container { get; }

        public NoteTabPage()
        {
            InitializeComponent();           
        }

        private void AddChild(Parameter name, NavigationParameters parameters)
        {
            var page = _container.Resolve<object>(name) as Page;
            if (ViewModelLocator.GetAutowireViewModel(page) == null)
                ViewModelLocator.SetAutowireViewModel(page, true);

            (page as INavigatingAware)?.OnNavigatingTo(parameters);
            (page?.BindingContext as INavigatingAware)?.OnNavigatingTo(parameters);

            Children.Add(page);
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            var tabs = parameters.GetValues<Parameter>("addTab");
            foreach (var name in tabs)
                AddChild(name, parameters);
        }
    }
}
