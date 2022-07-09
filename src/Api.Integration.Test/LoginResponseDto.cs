using System;
using Newtonsoft.Json;

namespace Api.Integration.Test
{
    public class LoginResponseDto
    {
        [JsonProperty("Authenticated")]
        public bool Authenticated { get; set; }

        [JsonProperty("CreateDate")]
        public DateTime CreateDate { get; set; }

        [JsonProperty("ExpirationDate")]
        public DateTime ExpirationDate { get; set; }

        [JsonProperty("AccessToken")]
        public string AccessToken { get; set; }

        [JsonProperty("UserEmail")]
        public string UserEmail { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Message")]
        public string Message { get; set; }
    }

}
