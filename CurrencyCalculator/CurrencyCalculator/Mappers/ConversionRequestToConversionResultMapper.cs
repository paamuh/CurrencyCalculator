using CurrencyCalculator.CurrencyCalculator.Models.Request;
using CurrencyCalculator.CurrencyCalculator.Models.Response;

namespace CurrencyCalculator.CurrencyCalculator.Mappers
{
    public static class ConversionRequestToConversionResultMapper
    {
        public static ConversionResultModel MapConversionRequestToConversionResult(
            ConversionRequestModel conversionRequest)
        {
            if (conversionRequest == null)
                return null;

            var conversionResultModel = new ConversionResultModel()
            {
                FromConversion = new FromConversion()
                {
                    Amount = conversionRequest.Amount,
                    CurrencyCode = conversionRequest.FromCurrency
                },
                ToConversion = new ToConversion()
                {
                    CurrencyCode = conversionRequest.ToCurrency
                }
            };

            if (!string.IsNullOrWhiteSpace(conversionRequest.Date))
                conversionResultModel.Date = conversionRequest.Date;

            return conversionResultModel;
        }
    }
}