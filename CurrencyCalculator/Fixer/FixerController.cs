using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace CurrencyCalculator.Fixer
{
    public class FixerController
    {
        private readonly FixerApiClient _fixerApiClient;

        public FixerController()
        {
            _fixerApiClient = new FixerApiClient();
        }

        public async Task<decimal> GetCurrentCurrencyFromTo(string fromCurrency, string toCurrency)
        {
            var result = await _fixerApiClient.GetCurrentCurrencyRatesFromTo(fromCurrency, toCurrency);

            return 0m;
        }

        public async Task<decimal> ConvertCurrencyFromAmountTo(string fromCurrency, string toCurrency, decimal amount)
        {
            var result = await _fixerApiClient.GetCurrentCurrencyRatesFromTo(fromCurrency, toCurrency);

            if (!result.Success) return 0m;

            var property = result.Rates.GetType().GetProperty(toCurrency);
            if (property != null)
            {
                var toRate = property.GetValue(result.Rates, null).ToString();

                var decimalRate = decimal.Parse(toRate);

                return decimalRate * amount;
            }
            return 0m;
        }

        public async Task<decimal> ConvertCurrencyFromHistoricalRates(string fromCurrency, string toCurrency, decimal amount, string date)
        {
            var result = await _fixerApiClient.GetHistoricalCurrencyRatesFromTo(fromCurrency, toCurrency, date);

            if (!result.Success) return 0m;

            var property = result.Rates.GetType().GetProperty(toCurrency);
            if (property != null)
            {
                var toRate = property.GetValue(result.Rates, null).ToString();

                var decimalRate = decimal.Parse(toRate);

                return decimalRate * amount;
            }
            return 0m;
        }




    }
}