
using CurrencyWeb.Entities.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyWeb.Entities.Context
{
    public class CurrencyContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=localhost;Port=3306;Database=CurrencyDb;Uid=root;Pwd=my-samet-pw;";
            var serverVersion = new MySqlServerVersion(new Version(8, 1, 0));

            optionsBuilder.UseMySql(connectionString,serverVersion);
        }

        public DbSet<Currency> Currencies { get; set; }
        public DbSet<MoneyRate> MoneyRates { get; set; }
    }
}
