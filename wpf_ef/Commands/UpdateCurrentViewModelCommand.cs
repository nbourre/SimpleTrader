using SimpleTrader.FinancialModelingPrepAPI.Services;
using SimpleTrader.WPF.ViewModels.Factories;
using SimpleTrader.WPF.State.Navigators;
using SimpleTrader.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SimpleTrader.WPF.Commands
{
    public class UpdateCurrentViewModelCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly INavigator _navigator;
        private readonly IRootSimpleTraderViewModelFactory _viewModelFactory;

        public UpdateCurrentViewModelCommand(INavigator navigator, 
            IRootSimpleTraderViewModelFactory viewModelFactory)
        {
            _navigator = navigator;
            _viewModelFactory = viewModelFactory;
        }

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            if (parameter is ViewType)
            {
                ViewType vt = (ViewType)parameter;

                _navigator.CurrentViewModel = _viewModelFactory.CreateViewModel(vt);

            }
        }
    }
}