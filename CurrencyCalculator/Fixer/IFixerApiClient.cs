namespace CurrencyCalculator.Fixer
{
    public interface IFixerApiClient
    {
        decimal GetCurrentCurrencyFromTo(string fromCurrency, string toCurrency);
    }
}