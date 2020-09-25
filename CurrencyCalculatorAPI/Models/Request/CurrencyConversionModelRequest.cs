namespace CurrencyCalculatorAPI.Models.Request
{
    public class CurrencyConversionModelRequest
    {
        public string CurrencyFrom { get; set; }
        public string CurrencyTo { get; set; }
        public decimal Amount { get; set; }
    }
}