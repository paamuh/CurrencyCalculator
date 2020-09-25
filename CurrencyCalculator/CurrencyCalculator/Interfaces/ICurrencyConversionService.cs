using System.Threading.Tasks;
using CurrencyCalculator.CurrencyCalculator.Models.Request;

namespace CurrencyCalculator.CurrencyCalculator.Interfaces
{
    public interface ICurrencyConversionService
    {
        Task<decimal> GetCurrentCurrencyFromTo(ConversionRequestModel conversionRequest);
        Task<decimal> ConvertCurrencyFromAmountTo(ConversionRequestModel conversionRequest);
        Task<decimal> ConvertCurrencyFromHistoricalRates(ConversionRequestModel conversionRequest);
    }
}