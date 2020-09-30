using System;
using System.Threading.Tasks;
using CurrencyCalculator.CurrencyCalculator.Fixer;
using CurrencyCalculator.CurrencyCalculator.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RazorCurrencyRatesDB.Data;
using RazorCurrencyRatesDB.Mappers;

namespace RazorCurrencyRatesDB.Client
{
    public static class CurrencyRatesDbClient
    {
        public static async Task AddCurrentRatesToDb(IServiceProvider serviceProvider)
        {
            var fixerApiClient = new FixerApiClient();
            var currentRates = await fixerApiClient.GetAllCurrentRates();

            var currentRatesDb =
                FixerResponseToDbCurrencyRatesMapper.MapFixerResponseModelToDbCurrencyModel(currentRates);

            using (var context =
                new RazorCurrencyRatesDBContext(serviceProvider.GetRequiredService<DbContextOptions<RazorCurrencyRatesDBContext>>()))
            {
                context.CurrencyRates.AddRange(currentRatesDb);

                context.SaveChanges();
            }
        }
    }
}