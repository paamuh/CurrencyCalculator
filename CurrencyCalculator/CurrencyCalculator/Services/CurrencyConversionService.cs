using System.Threading.Tasks;
using CurrencyCalculator.CurrencyCalculator.Fixer;
using CurrencyCalculator.CurrencyCalculator.Interfaces;
using CurrencyCalculator.CurrencyCalculator.Mappers;
using CurrencyCalculator.CurrencyCalculator.Models.Request;
using CurrencyCalculator.CurrencyCalculator.Models.Response;

namespace CurrencyCalculator.CurrencyCalculator.Services
{
    public class CurrencyConversionService : ICurrencyConversionService
    {
        private readonly FixerApiClient _fixerApiClient;

        public CurrencyConversionService()
        {
            _fixerApiClient = new FixerApiClient();
        }

        public async Task<RatesResponseModel> GetAllCurrentRates()
        {
            return await _fixerApiClient.GetAllCurrentRates();
        }

        public Task<ConversionResultModel> GetCurrentCurrencyFromTo(ConversionRequestModel conversionRequest)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ConversionResultModel> ConvertCurrencyFromAmountTo(ConversionRequestModel conversionRequest)
        {
            var conversionResult = ConversionRequestToConversionResultMapper.MapConversionRequestToConversionResult(conversionRequest);

            var response = await _fixerApiClient.GetCurrentCurrencyRatesFromTo(conversionRequest);

            if (!response.Success) return conversionResult;

            conversionResult.ToConversion.Amount = GetConvertedAmount(response, conversionRequest);

            return conversionResult;
        }

        public async Task<ConversionResultModel> ConvertCurrencyFromHistoricalRates(ConversionRequestModel conversionRequest)
        {
            var conversionResult = ConversionRequestToConversionResultMapper.MapConversionRequestToConversionResult(conversionRequest);

            var response = await _fixerApiClient.GetHistoricalCurrencyRatesFromTo(conversionRequest);

            if (!response.Success) return conversionResult;//return conversionResult

            conversionResult.ToConversion.Amount = GetConvertedAmount(response, conversionRequest);

            return conversionResult;
        }

        private decimal GetConvertedAmount(RatesResponseModel rates, ConversionRequestModel conversionRequest)
        {
            var property = rates.Rates.GetType().GetProperty(conversionRequest.ToCurrency);
            if (property == null) return 0m;
            var toRate = property.GetValue(rates.Rates, null).ToString();

            var decimalRate = decimal.Parse(toRate);

            return decimalRate * conversionRequest.Amount;
        }
    }
}