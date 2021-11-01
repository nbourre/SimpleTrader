using SimpleTrader.WPF.State.Navigators;
using wpf_ef.ViewModels;

namespace SimpleTrader.WPF.ViewModels.Factories
{
    public interface IRootSimpleTraderViewModelFactory
    {
        BaseViewModel CreateViewModel(ViewType viewType);
    }
}
