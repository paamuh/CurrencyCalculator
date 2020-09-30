using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorCurrencyRatesDB.Models;

namespace RazorCurrencyRatesDB.Data
{
    public class RazorCurrencyRatesDBContext : DbContext
    {
        public RazorCurrencyRatesDBContext (DbContextOptions<RazorCurrencyRatesDBContext> options)
            : base(options)
        {
        }

        public DbSet<RazorCurrencyRatesDB.Models.CurrencyRatesDbModel> CurrencyRates { get; set; }
    }
}
