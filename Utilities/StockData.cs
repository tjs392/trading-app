using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MarketApp.Utilities
{
    public class StockData
    {
        [JsonPropertyName("Meta Data")]
        public MetaData MetaData {get; set; }

        [JsonPropertyName("Time Series (Daily)")]
        public Dictionary<string, DailyStockData> TimeSeriesDaily { get; set; }
    }
}

public class MetaData
{
    [JsonPropertyName("2. Symbol")]
    public string Symbol { get; set; }
}

public class DailyStockData
{
    [JsonPropertyName("1. open")]
    public string Open { get; set; }

    [JsonPropertyName("2. high")]
    public string High { get; set; }

    [JsonPropertyName("3. low")]
    public string Low { get; set; }

    [JsonPropertyName("4. close")]
    public string Close { get; set; }

    [JsonPropertyName("5. volume")]
    public string Volume { get; set; }
}