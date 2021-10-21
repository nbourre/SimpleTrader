using SimpleTrader.Domain.Models;
using System;

namespace SimplerTrader.Domain.Models
{
    public class AssetTransaction : DomainObject
    {
        public Account Account { get; set; }
        public bool IsPurchase { get; set; }
        public Stock Stock { get; set; }
        public int Shares { get; set; }
        public DateTime DateProcessed { get; set; }
    }
}
