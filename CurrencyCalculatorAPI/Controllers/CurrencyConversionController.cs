using System.Threading.Tasks;
using CurrencyCalculatorAPI.Interfaces;
using CurrencyCalculatorAPI.Models.Request;
using CurrencyCalculatorAPI.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyCalculatorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyConversionController : Controller
    {
        private readonly ICurrencyService _currencyService;

        public CurrencyConversionController(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        [HttpGet]
        public async Task<CurrencyConversionModelResponse> GetAllAsync()
        {
            var conversionRequest = new CurrencyConversionModelRequest()
            {
                CurrencyFrom = "EUR",
                CurrencyTo = "USD",
                Amount = 100
            };

            var result = new CurrencyConversionModelResponse()
            {
                FromConversion = new FromConversion()
                {
                    CurrencyCode = conversionRequest.CurrencyFrom,
                    Amount = conversionRequest.Amount
                },
                ToConversion = new ToConversion()
                {
                    CurrencyCode = conversionRequest.CurrencyTo
                }
            };

            var conversionResult = await _currencyService.ConvertCurrencyFromAmountTo(conversionRequest);
            return conversionResult;
        }

        [HttpPost("[action]")]
        public async Task<CurrencyConversionModelResponse> ConvertCurrencyFromAmountTo([FromBody]CurrencyConversionModelRequest conversionRequest)
        {
            var conversionResult = await _currencyService.ConvertCurrencyFromAmountTo(conversionRequest);
            return conversionResult;
        }
    }
}