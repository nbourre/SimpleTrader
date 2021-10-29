using SimpletTrader.WPF.State.Navigators;
using wpf_ef.ViewModels;

namespace SimpleTrader.WPF.ViewModels.Factories
{
    public interface ISimpleTraderViewModelAbstractFactory
    {
        BaseViewModel CreateViewModel(ViewType viewType);
    }
}
