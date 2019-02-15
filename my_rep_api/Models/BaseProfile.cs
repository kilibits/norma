using System;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace myrep.Models {

    [Serializable]
    [BsonIgnoreExtraElements]
    public class BaseProfile{

        [BsonElement("id")]
        [JsonProperty(PropertyName = "profileId")]
        public int ProfileId {get; set;}

        [BsonElement("fullName")]
        [JsonProperty(PropertyName = "fullName")]
        public string FullName { get; set;}

        [JsonProperty(PropertyName = "politicalParty")]
        public string PoliticalParty {get; set;}
    }
}