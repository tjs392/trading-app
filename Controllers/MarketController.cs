using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using MarketApp.Models;
using MarketApp.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace MarketApp.Controllers
{
    public class MarketController : Controller
    {
        private readonly MarketService _marketService;

        public MarketController(MarketService marketService)
        {
            _marketService = marketService;
        }

        [HttpGet("Market/{symbol}")]
        public async Task<IActionResult> Index(string symbol = "MSFT")
        {
            var jsonData = await _marketService.GetData(symbol);
            var stockData = JsonSerializer.Deserialize<StockData>(jsonData, new JsonSerializerOptions { PropertyNameCaseInsensitive = true});

            if (stockData == null || stockData.TimeSeriesDaily == null)
            {
                // Log the error or handle the case where stockData is null
                return Problem(jsonData);
            }

            List<StockPriceModel> models = new List<StockPriceModel>();
            
            foreach (var dailyData in stockData.TimeSeriesDaily)
            {
                models.Add(new StockPriceModel
                {
                    Ticker = stockData.MetaData.Symbol,
                    Date = dailyData.Key,
                    Open = decimal.Parse(dailyData.Value.Open),
                    High = decimal.Parse(dailyData.Value.High),
                    Low = decimal.Parse(dailyData.Value.Low),
                    Close = decimal.Parse(dailyData.Value.Close),
                    Volume = decimal.Parse(dailyData.Value.Volume)
                });
            }
            return View(models);
            /*var jsonData = await _marketService.GetData(symbol);
            var data = new StockPriceModel
            {
                Symbol = symbol,
                Data = jsonData
            };
            return Ok(jsonData);*/
        }
    }
}