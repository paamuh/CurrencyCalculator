namespace CurrencyCalculator.CurrencyCalculator.Models.Response
{
    public class ConversionResultModel
    {
        public FromConversion FromConversion { get; set; }
        public ToConversion ToConversion { get; set; }
        public string Date { get; set; }
    }

    public class FromConversion
    {
        public string CurrencyCode { get; set; }
        public decimal Amount { get; set; }
    }

    public class ToConversion
    {
        public string CurrencyCode { get; set; }
        public decimal Amount { get; set; }
    }
}