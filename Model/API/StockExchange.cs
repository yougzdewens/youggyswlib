using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace YouggySWLib.Model.API
{
    public class StockExchange
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("acronym")]
        public string Acronym { get; set; }

        [JsonProperty("mic")]
        public string Mic { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("website")]
        public string Website { get; set; }
    }
}
