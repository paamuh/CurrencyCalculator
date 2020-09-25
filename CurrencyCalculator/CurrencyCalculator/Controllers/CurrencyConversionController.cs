using System.Threading.Tasks;
using CurrencyCalculator.CurrencyCalculator.Interfaces;
using CurrencyCalculator.CurrencyCalculator.Models.Request;
using CurrencyCalculator.CurrencyCalculator.Models.Response;

namespace CurrencyCalculator.CurrencyCalculator.Controllers
{
    public class CurrencyConversionController
    {
        private readonly ICurrencyConversionService _currencyConversionService;

        public CurrencyConversionController(ICurrencyConversionService currencyConversionService)
        {
            _currencyConversionService = currencyConversionService;
        }

        public async Task<ConversionResultModel> GetCurrentCurrencyFromTo(string fromCurrency, string toCurrency)
        {
            var request = new ConversionRequestModel()
            {
                FromCurrency = fromCurrency,
                ToCurrency = toCurrency
            };
            return await _currencyConversionService.GetCurrentCurrencyFromTo(request);
        }

        public async Task<ConversionResultModel> ConvertCurrencyFromAmountTo(string fromCurrency, string toCurrency, decimal amount)
        {
            var request = new ConversionRequestModel()
            {
                FromCurrency = fromCurrency,
                ToCurrency = toCurrency,
                Amount = amount
            };

            return await _currencyConversionService.ConvertCurrencyFromAmountTo(request);
        }

        public async Task<ConversionResultModel> ConvertCurrencyFromHistoricalRates(string fromCurrency, string toCurrency, decimal amount, string date)
        {
            //todo: Check if all values in controller is valid
            var request = new ConversionRequestModel()
            {
                FromCurrency = fromCurrency,
                ToCurrency = toCurrency,
                Amount = amount,
                Date = date
            };

            return await _currencyConversionService.ConvertCurrencyFromHistoricalRates(request);
        }
    }
}