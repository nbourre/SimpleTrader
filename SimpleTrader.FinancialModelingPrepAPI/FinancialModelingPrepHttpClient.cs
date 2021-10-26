using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.FinancialModelingPrepAPI
{
    public class FinancialModelingPrepHttpClient : HttpClient
    {
        public string DontDoThat = "?apikey=fd9b5be0f1e85b9aa1b854cb31de6828";
        public FinancialModelingPrepHttpClient()
        {
            BaseAddress = new Uri("https://financialmodelingprep.com/api/v3/");
        }

        public async Task<T> GetAsync<T>(string uri)
        {
            HttpResponseMessage response = await GetAsync(uri + DontDoThat);

            string jsonResponse = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<T>(jsonResponse);

            return result;
        }
    }
}
