using CurrencyCalculator.CurrencyCalculator.Models.Response;
using CurrencyCalculatorAPI.Models.Response;
using FromConversion = CurrencyCalculatorAPI.Models.Response.FromConversion;
using ToConversion = CurrencyCalculatorAPI.Models.Response.ToConversion;

namespace CurrencyCalculatorAPI.Mappers
{
    public static class ConversionResultToCurrencyConversionResponseMapper
    {
        public static CurrencyConversionModelResponse MapConversionResultToCurrencyConversion(ConversionResultModel conversionResult)
        {
            if (conversionResult == null)
                return null;

            var conversionResponse = new CurrencyConversionModelResponse()
            {
                FromConversion = new FromConversion(),
                ToConversion = new ToConversion()
            };

            if (conversionResult.FromConversion != null)
            {
                conversionResponse.FromConversion.CurrencyCode = conversionResult?.FromConversion?.CurrencyCode;
                conversionResponse.FromConversion.Amount = conversionResult.FromConversion.Amount;
            }

            if (conversionResult.ToConversion != null)
            {
                conversionResponse.ToConversion.CurrencyCode = conversionResult?.ToConversion?.CurrencyCode;
                conversionResponse.ToConversion.Amount = conversionResult.ToConversion.Amount;
            }

            if (string.IsNullOrWhiteSpace(conversionResult.Date))
                conversionResponse.Date = conversionResult.Date;

            return conversionResponse;
        }
    }
}