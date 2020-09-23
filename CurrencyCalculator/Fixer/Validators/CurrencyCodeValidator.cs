using CurrencyCalculator.Fixer.Models.Respons;

namespace CurrencyCalculator.Fixer.Validators
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