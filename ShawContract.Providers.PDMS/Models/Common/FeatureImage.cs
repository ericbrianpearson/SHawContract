
using Newtonsoft.Json;

namespace ShawContract.Providers.PDMS.Models.Common
{
    public class FeatureImage
    {
        [JsonProperty("imagePath")]
        public string ImagePath { get; set; }
    }
}
