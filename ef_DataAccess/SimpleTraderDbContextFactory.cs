using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.EF
{
    public class SimpleTraderDbContextFactory : IDesignTimeDbContextFactory<SimpleTraderDbContext>
    {
        public SimpleTraderDbContext CreateDbContext(string[] args = null)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SimpleTraderDbContext>();
            optionsBuilder.UseSqlite(@"Data Source=Data\SimpleTrader.db");
            
            return new SimpleTraderDbContext(optionsBuilder.Options);

        }

    }
}
