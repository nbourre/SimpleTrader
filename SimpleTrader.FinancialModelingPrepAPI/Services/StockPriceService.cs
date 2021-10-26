using SimpleTrader.Domain.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using SimpleTrader.FinancialModelingPrepAPI.Results;
using SimpleTrader.Domain.Exceptions;

namespace SimpleTrader.FinancialModelingPrepAPI.Services
{
    public class StockPriceService : IStockPriceService
    {
        public async Task<double> GetPrice(string symbol)
        {
            using (var client = new FinancialModelingPrepHttpClient())
            {
                string uri = $"quote-short/{symbol}";

                var stockPrices = await client.GetAsync<List<StockPriceResult>>(uri);

                if (stockPrices.Count == 0) {
                    throw new InvalidSymbolException(symbol);
                }

                var stock = stockPrices[0];

                return stock.Price;
            }
        }
    }
}
