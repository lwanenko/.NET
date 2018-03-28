using Note.Events;
using Note.Services;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Note.ViewModels
{
	public class NoteTabPageViewModel : ViewModelBase
    {
        IEventAggregator _ea { get; }


        public NoteTabPageViewModel  (IEventAggregator eventAggregator, INavigationService navigationService) : base (navigationService)
        {
            _ea = eventAggregator;
        }

        public override void OnNavigatingTo(Prism.Navigation.NavigationParameters parameters)
        {
            
            _ea.GetEvent<InitializeTabbedChildrenEvent>().Publish(parameters);
        }

    }
}
