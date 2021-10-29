using wpf_ef.ViewModels;

namespace SimpleTrader.WPF.ViewModels.Factories
{
    public interface ISimpleTraderViewModelFactory<T> where T : BaseViewModel
    {
        T CreateViewModel();
    }
}
