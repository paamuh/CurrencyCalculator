using CurrencyCalculator.CurrencyCalculator.Models.Response;

namespace CurrencyCalculator.CurrencyCalculator.Validators
{
    public static class CurrencyCodeValidator
    {
        public static bool ValidateCurrencyCode(string currencyCode)
        {
            var ratesResponseModel = new RatesResponseModel()
            {
                Rates = new Rates()
            };

            var property = ratesResponseModel.Rates.GetType().GetProperty(currencyCode);

            return property != null;
        }
    }
}