using Newtonsoft.Json;

namespace SC.App.Services.Area.Common.Responses
{
    public class ResponseError
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}