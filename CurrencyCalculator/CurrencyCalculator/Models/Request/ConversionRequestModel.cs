namespace CurrencyCalculator.CurrencyCalculator.Models.Request
{
    public class ConversionRequestModel
    {
        public string FromCurrency { get; set; }
        public string ToCurrency { get; set; }
        public decimal Amount { get; set; }
        public string Date { get; set; }
    }
}