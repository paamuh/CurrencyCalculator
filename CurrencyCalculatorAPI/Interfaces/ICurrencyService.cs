using System.Threading.Tasks;
using CurrencyCalculatorAPI.Models.Request;
using CurrencyCalculatorAPI.Models.Response;

namespace CurrencyCalculatorAPI.Interfaces
{
    public interface ICurrencyService
    {
        Task<CurrencyConversionModelResponse> ConvertCurrencyFromAmountTo(CurrencyConversionModelRequest conversionRequest);
    }
}