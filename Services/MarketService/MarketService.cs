using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketApp.Services.MarketService
{
    public class MarketService
    {
        private readonly HttpClient _httpClient;
        private const string ApiKey = "G9ZUHK21JIYMV8CO";

        public MarketService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetData(string symbol)
        {
            var url = $"https://www.alphavantage.co/query?function=TIME_SERIES_WEEKLY&symbol={symbol}&interval=5min&apikey={ApiKey}";
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}