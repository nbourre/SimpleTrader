using SimplerTrader.Domain;
using SimplerTrader.Domain.Models;
using SimpleTrader.Domain.Exceptions;
using System;
using System.Threading.Tasks;

namespace SimpleTrader.Domain.Services.TransactionServices
{
    public class BuyStockService : IBuyStockService
    {
        private readonly IStockPriceService _stockPriceService;
        private readonly IDataService<Account> _accountService;

        public BuyStockService(IStockPriceService stockPriceService, IDataService<Account> accountService)
        {
            _stockPriceService = stockPriceService;
            _accountService = accountService;
        }

        public async Task<Account> BuyStock(Account buyer, string symbol, int shares)
        {
            double stockPrice = await _stockPriceService.GetPrice(symbol);

            var transactionPrice = stockPrice * shares;

            if (transactionPrice > (double)buyer.Balance)
            {
                throw new InsufficientFundsException((double)buyer.Balance, stockPrice * shares);
            }

            AssetTransaction transaction = new AssetTransaction()
            {
                Account = buyer,
                Asset = new Asset()
                {
                    PricePerShare = stockPrice,
                    Symbol = symbol,
                },
                DateProcessed = DateTime.Now,
                Shares = shares,
                IsPurchase = true,
            };

            buyer.AssetTransactions.Add(transaction);
            buyer.Balance -= (decimal)transactionPrice;

            await _accountService.Update(buyer.Id, buyer);

            return buyer;
        }
    }
}
