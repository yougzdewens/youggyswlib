using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace YouggySWLib.Model.API
{
    public class DayValues
    {
        [JsonProperty("pagination")]
        public Pagination Pagination { get; set; }

        [JsonProperty("data")]
        public List<DayValue> Data { get; set; }
    }
}