using Newtonsoft.Json;
using System;

namespace SmartHive.Services.JsonModels
{
    public class JsonHive
    {
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("field1")]
        public string Temperature { get; set; }

        [JsonProperty("field2")]
        public string Humidity { get; set; }
    }
}
