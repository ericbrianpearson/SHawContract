using Newtonsoft.Json;

namespace ShawContract.Providers.PDMS.Models
{
    public class Link
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}