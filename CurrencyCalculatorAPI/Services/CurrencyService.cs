using System.Threading.Tasks;
using CurrencyCalculator.CurrencyCalculator.Interfaces;
using CurrencyCalculator.CurrencyCalculator.Models.Request;
using CurrencyCalculatorAPI.Interfaces;
using CurrencyCalculatorAPI.Mappers;
using CurrencyCalculatorAPI.Models.Request;
using CurrencyCalculatorAPI.Models.Response;

namespace CurrencyCalculatorAPI.Services
{

    public class CurrencyService : ICurrencyService
    {
        private readonly ICurrencyConversionService _currencyConversionService;

        public CurrencyService(ICurrencyConversionService currencyConversionService)
        {
            _currencyConversionService = currencyConversionService;
        }

        public async Task<CurrencyConversionModelResponse> ConvertCurrencyFromAmountTo(CurrencyConversionModelRequest conversionRequest)
        {
            var request = new ConversionRequestModel()
            {
                FromCurrency = conversionRequest.CurrencyFrom,
                ToCurrency = conversionRequest.CurrencyTo,
                Amount = conversionRequest.Amount
            };

            var result = await _currencyConversionService.ConvertCurrencyFromAmountTo(request);

            var conversionResponse = new CurrencyConversionModelResponse();

            if(result != null)
                conversionResponse = ConversionResultToCurrencyConversionResponseMapper.MapConversionResultToCurrencyConversion(result);

            return conversionResponse;
        }
    }
}