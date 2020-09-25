using System.Threading.Tasks;
using CurrencyCalculator.CurrencyCalculator.Interfaces;
using CurrencyCalculator.CurrencyCalculator.Models.Request;

namespace CurrencyCalculator.CurrencyCalculator.Controllers
{
    public class CurrencyConversionController
    {
        private readonly ICurrencyConversionService _currencyConversionService;

        public CurrencyConversionController(ICurrencyConversionService currencyConversionService)
        {
            _currencyConversionService = currencyConversionService;
        }

        public async Task<decimal> GetCurrentCurrencyFromTo(string fromCurrency, string toCurrency)
        {
            var request = new ConversionRequestModel()
            {
                FromCurrency = fromCurrency,
                ToCurrency = toCurrency
            };

            var result = await _currencyConversionService.GetCurrentCurrencyFromTo(request);
            
            return result;
        }

        public async Task<decimal> ConvertCurrencyFromAmountTo(string fromCurrency, string toCurrency, decimal amount)
        {
            var request = new ConversionRequestModel()
            {
                FromCurrency = fromCurrency,
                ToCurrency = toCurrency,
                Amount = amount
            };

            var result = await _currencyConversionService.ConvertCurrencyFromAmountTo(request);

            return result;
        }

        public async Task<decimal> ConvertCurrencyFromHistoricalRates(string fromCurrency, string toCurrency, decimal amount, string date)
        {
            //todo: Check if all values in controller is valid
            var request = new ConversionRequestModel()
            {
                FromCurrency = fromCurrency,
                ToCurrency = toCurrency,
                Amount = amount,
                Date = date
            };

            var result = await _currencyConversionService.ConvertCurrencyFromHistoricalRates(request);

            return result;
        }




    }
}