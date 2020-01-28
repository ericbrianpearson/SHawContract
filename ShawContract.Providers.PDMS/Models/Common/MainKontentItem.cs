using System.Collections.Generic;
using Newtonsoft.Json;

namespace ShawContract.Providers.PDMS.Models
{
    public class MainKontentItem
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("imageUrl")]
        public string ImageUrl { get; set; }

        [JsonProperty("headline")]
        public string Headline { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("links")]
        public IEnumerable<Link> Links { get; set; }
    }
}