using Newtonsoft.Json;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.FinancialModelingPrepAPI.Services
{
    public class MajorIndexService : IMajorIndexService
    {
        public async Task<MajorIndex> GetMajorIndex(MajorIndexType indexType)
        {
            using (HttpClient client = new HttpClient())
            {
                var notbestway = "fd9b5be0f1e85b9aa1b854cb31de6828";

                string uri = $"https://financialmodelingprep.com/api/v3/quote/{GetUriSuffixe(indexType)}?apikey={notbestway}";

                /// TODO : Rendu https://www.youtube.com/watch?v=0SCKUine6tY&list=PLA8ZIAm2I03jSfo18F7Y65XusYzDusYu5&index=4&t=6m00s
                HttpResponseMessage response = await client.GetAsync(uri);

                string jsonResponse = await response.Content.ReadAsStringAsync();

                List<MajorIndex> majorIndices = JsonConvert.DeserializeObject<List<MajorIndex>>(jsonResponse);
                majorIndices[0].Type = indexType;
                return majorIndices[0];
            }
        }

        private string GetUriSuffixe(MajorIndexType indexType)
        {
            switch (indexType)
            {
                case MajorIndexType.DowJones:
                    return "^DJI";
                    break;
                case MajorIndexType.Nasdaq:
                    return "^IXIC";
                    break;
                case MajorIndexType.SP500:
                    return "^SP500TR";
                    break;
                default:
                    return "^DJI";
                    break;
            }
        }
    }
}