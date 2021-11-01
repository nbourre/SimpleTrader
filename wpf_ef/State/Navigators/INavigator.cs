using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using wpf_ef.ViewModels;

namespace SimpleTrader.WPF.State.Navigators
{
    public enum ViewType
    {
        Home,
        Portfolio,
        Buy,
    }
    public interface INavigator
    {
        BaseViewModel CurrentViewModel { get; set; }
        ICommand UpdateCurrentViewModelCommand { get; }
    }
}
