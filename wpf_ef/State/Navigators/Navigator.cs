using SimpleTrader.WPF.ViewModels.Factories;
using SimpleTrader.WPF.Commands;
using System.Windows.Input;
using wpf_ef.ViewModels;

namespace SimpleTrader.WPF.State.Navigators
{
    public class Navigator : BaseViewModel, INavigator
    {
        private BaseViewModel currentViewModel;

        public BaseViewModel CurrentViewModel {
            get => currentViewModel;
            set
            {
                currentViewModel = value;
                OnPropertyChanged();
            }
        }

        public ICommand UpdateCurrentViewModelCommand { get; set; }

        public Navigator(IRootSimpleTraderViewModelFactory viewModelFactory)
        {
            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(this, viewModelFactory);
        }
    }
}
