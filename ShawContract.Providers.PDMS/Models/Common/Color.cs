using Newtonsoft.Json;

namespace ShawContract.Providers.PDMS.Models
{
    public class Color
    {
        [JsonProperty("colorNumber")]
        public string ColorNumber { get; set; }

        [JsonProperty("colorName")]
        public string ColorName { get; set; }
    }
}