using SimpleTrader.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplerTrader.Domain.Models
{
    public class Account : DomainObject
    {
        public User AccountHolder { get; set; }
        public decimal Balance { get; set; }
        public IEnumerable<AssetTransaction> AssetTransactions { get; set; }

    }
}
