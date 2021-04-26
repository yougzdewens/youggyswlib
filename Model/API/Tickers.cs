using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace YouggySWLib.Model.API
{
    public class Tickers
    {
        [JsonProperty("pagination")]
        public Pagination Pagination { get; set; }

        [JsonProperty("data")]
        public List<Symbol> Data { get; set; }
    }
}
