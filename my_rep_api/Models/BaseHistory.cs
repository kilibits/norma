using System;
using Newtonsoft.Json;

namespace myrep.Models
{
    [Serializable]
    public class BaseHistory
    {
        [JsonProperty(PropertyName = "institution")]
        public string Institution { get; set; }

        [JsonProperty(PropertyName = "from")]
        public int? From { get; set; }

        [JsonProperty(PropertyName = "to")]
        public int? To { get; set; }
    }
}