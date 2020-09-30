using System.Threading.Tasks;
using CurrencyCalculator.CurrencyCalculator.Models.Response;

namespace CurrencyCalculator.CurrencyCalculator.Interfaces
{
    public interface IFixerApiClient
    {
        decimal GetCurrentCurrencyFromTo(string fromCurrency, string toCurrency);
        Task<RatesResponseModel> GetAllCurrentRates();
    }
}