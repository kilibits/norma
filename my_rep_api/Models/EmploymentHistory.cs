using System;
using Newtonsoft.Json;

namespace myrep.Models
{
    [Serializable]
    public class EmploymentHistory: BaseHistory
    {
        [JsonProperty(PropertyName = "position")]
        public string Position { get; set; }
    }
}