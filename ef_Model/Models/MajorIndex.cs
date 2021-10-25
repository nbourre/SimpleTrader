using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.Domain.Models
{
    public enum MajorIndexType
    {
        DowJones,
        Nasdaq,
        SP500
    }

    /// <summary>
    /// Pasted json as class
    /// </summary>
    public class Rootobject
    {
        public Quote[] quotes { get; set; }
    }

    public class Quote
    {
        public string symbol { get; set; }
        public string name { get; set; }
        public float price { get; set; }
        public float changesPercentage { get; set; }
        public float change { get; set; }
        public float dayLow { get; set; }
        public float dayHigh { get; set; }
        public float yearHigh { get; set; }
        public float yearLow { get; set; }
        public object marketCap { get; set; }
        public float priceAvg50 { get; set; }
        public float priceAvg200 { get; set; }
        public int volume { get; set; }
        public int avgVolume { get; set; }
        public string exchange { get; set; }
        public float open { get; set; }
        public float previousClose { get; set; }
        public object eps { get; set; }
        public object pe { get; set; }
        public object earningsAnnouncement { get; set; }
        public object sharesOutstanding { get; set; }
        public int timestamp { get; set; }
    }

    public class MajorIndex
    {
        public double Price { get; set; }
        public double Change { get; set; }
        public MajorIndexType Type { get; set; }
    }
}
