using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSnippets.Services.ViewModels
{
    public class VkRequestViewModel
    {
        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }
        [JsonProperty("#access_token")]
        public string AccessToken { get; set; }
        [JsonProperty("user_id")]
        public int UserId { get; set; }
    }
}
