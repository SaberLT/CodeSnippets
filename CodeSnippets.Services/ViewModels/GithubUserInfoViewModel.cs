using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSnippets.Services.ViewModels
{
    public class GithubUserInfoViewModel
    {
        public string Login { get; set; }
        public string Id { get; set; }
        [JsonProperty("avatar_url")]
        public string Avatar_Url { get; set; }
    }
}
