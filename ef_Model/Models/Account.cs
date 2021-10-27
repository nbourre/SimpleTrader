using SimpleTrader.Domain.Models;
using System.Collections.Generic;

namespace SimplerTrader.Domain.Models
{
    public class Account : DomainObject
    {
        public User AccountHolder { get; set; }
        public decimal Balance { get; set; }
        public ICollection<AssetTransaction> AssetTransactions { get; set; }

    }
}
