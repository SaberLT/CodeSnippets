using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSnippets.Services.ViewModels
{
    public class VkResponseViewModel
    {
        public string Id { get; set; }
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        [JsonProperty("is_closed")]
        public bool IsClosed { get; set; }
        [JsonProperty("can_access_closed")]
        public bool CanAccessClosed { get; set; }
        [JsonProperty("photo_50")]
        public string PhotoURL { get; set; }
    }
}
