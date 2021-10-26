using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplerTrader.Domain.Models
{
    public class Stock
    {
        // TODO : https://www.youtube.com/watch?v=TFfFVHBFqjY&list=PLA8ZIAm2I03jSfo18F7Y65XusYzDusYu5&index=8&t=20m20s
        public string Symbol { get; set; }
        public double PricePerShare { get; set; }
    }
}
