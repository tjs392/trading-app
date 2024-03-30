using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace MarketApp.Dtos
{
    public class MarketDataDto
    {
        public string Symbol { get; set; }
        public string Data { get; set; }
    }
}
