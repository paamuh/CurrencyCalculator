using System.Threading.Tasks;
using CurrencyCalculator.CurrencyCalculator.Fixer;
using CurrencyCalculator.CurrencyCalculator.Interfaces;
using CurrencyCalculator.CurrencyCalculator.Models.Request;

namespace CurrencyCalculator.CurrencyCalculator.Services
{
    public class CurrencyConversionService : ICurrencyConversionService
    {
        private readonly FixerApiClient _fixerApiClient;

        public CurrencyConversionService()
        {
            _fixerApiClient = new FixerApiClient();
        }


        public Task<decimal> GetCurrentCurrencyFromTo(ConversionRequestModel conversionRequest)
        {
            throw new System.NotImplementedException();
        }

        public async Task<decimal> ConvertCurrencyFromAmountTo(ConversionRequestModel conversionRequest)
        {
            var result = await _fixerApiClient.GetCurrentCurrencyRatesFromTo(conversionRequest);

            if (!result.Success) return 0m;

            var property = result.Rates.GetType().GetProperty(conversionRequest.ToCurrency);
            if (property != null)
            {
                var toRate = property.GetValue(result.Rates, null).ToString();

                var decimalRate = decimal.Parse(toRate);

                return decimalRate * conversionRequest.Amount;
            }
            return 0m;
        }

        public async Task<decimal> ConvertCurrencyFromHistoricalRates(ConversionRequestModel conversionRequest)
        {
            var result = await _fixerApiClient.GetHistoricalCurrencyRatesFromTo(conversionRequest);

            if (!result.Success) return 0m;

            var property = result.Rates.GetType().GetProperty(conversionRequest.ToCurrency);
            if (property != null)
            {
                var toRate = property.GetValue(result.Rates, null).ToString();

                var decimalRate = decimal.Parse(toRate);

                return decimalRate * conversionRequest.Amount;
            }
            return 0m;
        }
    }
}