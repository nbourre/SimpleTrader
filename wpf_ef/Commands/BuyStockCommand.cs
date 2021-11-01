using SimplerTrader.Domain.Models;
using SimpleTrader.Domain.Services.TransactionServices;
using SimpleTrader.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SimpleTrader.WPF.Commands
{
    public class BuyStockCommand : ICommand
    {
        private BuyViewModel _viewModel;
        private IBuyStockService _buyStockService;

        public BuyStockCommand(BuyViewModel viewModel, IBuyStockService buyStockService)
        {
            _viewModel = viewModel;
            _buyStockService = buyStockService;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            try
            {
                Account  account = await _buyStockService.BuyStock(
                    new SimplerTrader.Domain.Models.Account()
                    {
                        Id = 1,
                        Balance = 500,
                        AssetTransactions = new List<AssetTransaction>()
                    }, _viewModel.Symbol, _viewModel.SharesToBuy) ;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            
        }
    }
}
