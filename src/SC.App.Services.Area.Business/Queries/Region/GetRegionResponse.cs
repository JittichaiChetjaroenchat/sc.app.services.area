using System;
using Newtonsoft.Json;

namespace SC.App.Services.Area.Business.Queries.Region
{
    public class GetRegionResponse
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}