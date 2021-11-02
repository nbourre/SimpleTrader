using SimpleTrader.Domain.Services;
using SimpleTrader.Domain.Services.TransactionServices;
using SimpleTrader.WPF.Commands;
using System.Windows.Input;
using wpf_ef.ViewModels;

namespace SimpleTrader.WPF.ViewModels
{
    public class BuyViewModel : BaseViewModel
    {
        private string symbol;

        public string Symbol
        {
            get { return symbol; }
            set { 
                symbol = value.ToUpper();
                OnPropertyChanged();
            }
        }

        private string searchResultSymbol = string.Empty;

        public string SearchResultSymbol
        {
            get { return searchResultSymbol; }
            set { 
                searchResultSymbol = value;
                OnPropertyChanged();
            }
        }


        private double stockPrice;

        public double StockPrice
        {
            get { return stockPrice; }
            set {
                stockPrice = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(TotalPrice));
            }
        }

        private int sharesToBuy;

        public int SharesToBuy
        {
            get { return sharesToBuy; }
            set { 
                sharesToBuy = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(TotalPrice));
            }
        }

        public double TotalPrice => StockPrice * SharesToBuy;

        public ICommand SearchSymbolCommand { get; set; }
        public ICommand BuyStockCommand { get; set; }

        public BuyViewModel(IStockPriceService stockPriceService, IBuyStockService buyStockService)
        {
            SearchSymbolCommand = new SearchSymbolCommand(this, stockPriceService);
            BuyStockCommand = new BuyStockCommand(this, buyStockService);
        }

    }
}
