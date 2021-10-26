using SimplerTrader.Domain;
using SimplerTrader.Domain.Models;
using SimpletTrader.WPF.State.Navigators;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace wpf_ef.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public INavigator Navigator { get; set; } = new Navigator();

        public MainViewModel()
        {
            Navigator.UpdateCurrentViewModelCommand.Execute(ViewType.Home);
        }
    }
}