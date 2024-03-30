using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketApp.Services.MarketService
{
    public class MarketService
    {
        private readonly HttpClient _httpClient;
        private const string ApiKey = "NZQQW7C8SLHYJFB0";

        public MarketService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetData(string symbol, string outputSize = "compact")
        {
            var url = $"https://www.alphavantage.co/query?function=TIME_SERIES_DAILY&symbol={symbol}&outputsize={outputSize}&apikey={ApiKey}";
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}