using System;
using System.Net.Http;
using System.Reflection.PortableExecutable;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using CurrencyCalculator.Fixer.Models.Respons;

namespace CurrencyCalculator.Fixer
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

        public async Task<RatesResponseModel> GetHistoricalCurrencyRatesFromTo(string fromCurrency,
            string toCurrency, string date)
        {
            var url = date + "?access_key=" + AccessKey + "&base=" + fromCurrency + "&symbols=" + toCurrency;

            var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode) return null;
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<RatesResponseModel>(json);
        }
        //TODO: Date validator? In the controller.

        public async Task<RatesResponseModel> GetCurrentCurrencyRatesFromTo(string fromCurrency, string toCurrency)
        {
            var url = "latest?access_key=" + AccessKey + "&base=" + fromCurrency + "&symbols=" + toCurrency;

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