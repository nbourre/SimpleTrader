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
            using (var client = new FinancialModelingPrepHttpClient())
            {
                string uri = $"quote/{GetUriSuffixe(indexType)}";

                var majorIndexes = await client.GetAsync<List<MajorIndex>>(uri);

                majorIndexes[0].Type = indexType;
                return majorIndexes[0];
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
                    throw new Exception("MajorIndexType does not have a suffix defined.");
            }
        }
    }
}