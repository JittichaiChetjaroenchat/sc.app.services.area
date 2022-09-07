using System;
using Newtonsoft.Json;

namespace SC.App.Services.Area.Business.Queries.Area
{
    public class GetAreaResponse
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("region")]
        public GetRegion Region { get; set; }

        [JsonProperty("province")]
        public string Province { get; set; }

        [JsonProperty("district")]
        public string District { get; set; }

        [JsonProperty("sub_district")]
        public string SubDistrict { get; set; }

        [JsonProperty("postal_code")]
        public string PostalCode { get; set; }

        [JsonProperty("is_capital")]
        public bool IsCapital { get; set; }

        [JsonProperty("is_perimeter")]
        public bool IsPerimeter { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }
    }

    public class GetRegion
    {
        [JsonProperty("code")]
        public string Code { get; set; }
    }
}