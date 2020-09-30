using System.Threading.Tasks;
using CurrencyCalculator.CurrencyCalculator.Models.Request;
using CurrencyCalculator.CurrencyCalculator.Models.Response;

namespace CurrencyCalculator.CurrencyCalculator.Interfaces
{
    public interface ICurrencyConversionService
    {
        Task<RatesResponseModel> GetAllCurrentRates();
        Task<ConversionResultModel> GetCurrentCurrencyFromTo(ConversionRequestModel conversionRequest);
        Task<ConversionResultModel> ConvertCurrencyFromAmountTo(ConversionRequestModel conversionRequest);
        Task<ConversionResultModel> ConvertCurrencyFromHistoricalRates(ConversionRequestModel conversionRequest);
    }
}