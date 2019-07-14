using System;
using Newtonsoft.Json;
using MongoDB.Bson.Serialization.Attributes;

namespace myrep.Models
{
    [Serializable]
    [BsonIgnoreExtraElements]
    public class Profile: BaseProfile
    {
        [JsonProperty(PropertyName = "constituency")]
        public string Constituency { get; set; }

        [JsonProperty(PropertyName = "eMail")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "phone")]
        public string Phone { get; set; }

        [JsonProperty(PropertyName = "memberType")]
        public string MemberType { get; set; }

        [JsonProperty(PropertyName = "address")]
        public string Address { get; set; }

        [JsonProperty(PropertyName = "birthDate")]
        public string BirthDate { get; set; }

        [JsonProperty(PropertyName = "term")]
        public int? Term { get; set; }

        [JsonProperty(PropertyName = "imageUrl")]
        public string ImageSource { get; set; }

        [JsonProperty(PropertyName = "profileSource")]
        public string ProfileSource { get; set; }
    }
}