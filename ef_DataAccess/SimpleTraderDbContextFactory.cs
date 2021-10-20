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
        public SimpleTraderDbContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<SimpleTraderDbContext>();
            options.UseSqlite(@"Data Source=Data\SimpleTrader.db");

        }
    }
}
