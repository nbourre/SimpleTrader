using SimpleTrader.Domain.Services;
using SimpleTrader.WPF.ViewModels;
using System;
using System.Windows;
using System.Windows.Input;

namespace SimpleTrader.WPF.Commands
{
    public class SearchSymbolCommand : ICommand
    {
        private readonly BuyViewModel _viewModel;
        private readonly IStockPriceService _stockPriceService;
        public event EventHandler CanExecuteChanged;


        public SearchSymbolCommand(BuyViewModel viewModel, IStockPriceService stockPriceService)
        {
            _viewModel = viewModel;
            _stockPriceService = stockPriceService;
        }

        public bool CanExecute(object parameter) => true;
        

        public async void Execute(object parameter)
        {

            try
            {
                _viewModel.StockPrice = await _stockPriceService.GetPrice(_viewModel.Symbol);
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }        
        }
    }
}
