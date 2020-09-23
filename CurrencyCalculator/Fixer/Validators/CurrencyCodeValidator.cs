using CurrencyCalculator.Fixer.Models.Respons;

namespace CurrencyCalculator.Fixer.Validators
{
    public class CurrencyCodeValidator
    {
        public bool ValidateCurrencyCode(string currencyCode)
        {
            var ratesResponseModel = new RatesResponseModel();

            var property = ratesResponseModel.Rates.GetType().GetProperty(currencyCode);

            var jeppjpep = property;

            return false;
        }
    }
}