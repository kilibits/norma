using System;
using Newtonsoft.Json;

namespace myrep.Models
{
    [Serializable]
    public class EducationHistory: BaseHistory
    {
        [JsonProperty(PropertyName = "level")]
        public string Level { get; set; }

        [JsonProperty(PropertyName = "award")]
        public string Award { get; set; }
    }
}