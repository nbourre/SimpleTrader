using SimplerTrader.Domain;
using SimplerTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.Domain.Services.TransactionServices;
using SimpleTrader.EF;
using SimpleTrader.EF.Services;
using SimpleTrader.FinancialModelingPrepAPI.Services;
using System.Windows;
using wpf_ef.ViewModels;

namespace wpf_ef
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override async void OnStartup(StartupEventArgs e)
        {
            IStockPriceService stockPriceService = new StockPriceService();
            IDataService<Account> accountService = new AccountDataService(new SimpleTraderDbContextFactory());
            IBuyStockService buyStockService = new BuyStockService(stockPriceService, accountService);

            Account buyer = await accountService.Get(1);

            await buyStockService.BuyStock(buyer, "T", 5000);

            MainWindow win = new MainWindow();

            win.DataContext = new MainViewModel();

            win.Show();

            base.OnStartup(e);
        }
    }
}
