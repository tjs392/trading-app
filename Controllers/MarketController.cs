using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using MarketApp.Dtos;
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
        public async Task<ActionResult<MarketDataDto>> Index(string symbol = "MSFT")
        {
            var jsonData = await _marketService.GetData(symbol);
            var data = new MarketDataDto
            {
                Symbol = symbol,
                Data = jsonData
            };
            return Ok(jsonData);
        }
    }
}