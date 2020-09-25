using System;
using System.Net.Http;
using System.Threading.Tasks;
using CurrencyCalculator.CurrencyCalculator.Models.Request;
using CurrencyCalculator.CurrencyCalculator.Models.Response;
using Newtonsoft.Json;

namespace CurrencyCalculator.CurrencyCalculator.Fixer
{
    public class FixerApiClient
    {
        private const string AccessKey = "883764c31911e5802a6a89ba4d796305";
        private const string BaseUrl = "http://data.fixer.io/api/";
        private HttpClient _httpClient;

        public FixerApiClient()
        {
            InitilizeHttpClient();
        }

        private ConversionRequestModel ConvertStringsToCapital(ConversionRequestModel conversionRequest)
        {
            if (!string.IsNullOrWhiteSpace(conversionRequest.FromCurrency))
                conversionRequest.FromCurrency = conversionRequest.FromCurrency.ToUpper();

            if (!string.IsNullOrWhiteSpace(conversionRequest.ToCurrency))
                conversionRequest.ToCurrency = conversionRequest.ToCurrency.ToUpper();

            return conversionRequest;
        }

        public async Task<RatesResponseModel> GetHistoricalCurrencyRatesFromTo(ConversionRequestModel conversionRequest)
        {
            conversionRequest = ConvertStringsToCapital(conversionRequest);

            var url = conversionRequest.Date + "?access_key=" + AccessKey + "&base=" + conversionRequest.FromCurrency + "&symbols=" + conversionRequest.ToCurrency;

            var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode) return null;
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<RatesResponseModel>(json);
        }
        //TODO: Date validator? In the controller.

        public async Task<RatesResponseModel> GetCurrentCurrencyRatesFromTo(ConversionRequestModel conversionRequest)
        {
            conversionRequest = ConvertStringsToCapital(conversionRequest);

            var url = "latest?access_key=" + AccessKey + "&base=" + conversionRequest.FromCurrency + "&symbols=" + conversionRequest.ToCurrency;

            var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode) return null;
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<RatesResponseModel>(json);
        }

        public async Task<RatesResponseModel> GetCurrentAllRates()
        {
            var url = "latest?access_key=" + AccessKey;

            var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode) return null;
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<RatesResponseModel>(json);
        }


        private void InitilizeHttpClient()
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri(BaseUrl)
            };
        }
    }
}