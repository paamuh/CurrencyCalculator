namespace CurrencyCalculator.CurrencyCalculator.Interfaces
{
    public interface IFixerApiClient
    {
        decimal GetCurrentCurrencyFromTo(string fromCurrency, string toCurrency);
    }
}