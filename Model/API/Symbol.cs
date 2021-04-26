using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace YouggySWLib.Model.API
{
    public class Symbol
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("symbol")]
        public string SymbolText { get; set; }

        [JsonProperty("has_intraday")]
        public bool HasIntraday { get; set; }

        [JsonProperty("has_eod")]
        public bool HasEod { get; set; }

        [JsonProperty("country")]
        public object Country { get; set; }

        [JsonProperty("stock_exchange")]
        public StockExchange StockExchange { get; set; }
    }
}
