using SimpletTrader.WPF.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using wpf_ef.ViewModels;

namespace SimpletTrader.WPF.State.Navigators
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

        public ICommand UpdateCurrentViewModelCommand => new UpdateCurrentViewModelCommand(this);
    }
}
