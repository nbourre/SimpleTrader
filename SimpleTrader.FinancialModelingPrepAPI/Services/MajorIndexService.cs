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
        public Task<MajorIndex> GetMajorIndex(MajorIndexType indexType)
        {
            using (HttpClient client = new HttpClient())
            {
                /// TODO : Rendu https://www.youtube.com/watch?v=0SCKUine6tY&list=PLA8ZIAm2I03jSfo18F7Y65XusYzDusYu5&index=4&t=6m00s
                ///await client.GetAsync()
            }
        }
    }
}
