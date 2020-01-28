using Newtonsoft.Json;

namespace ShawContract.Providers.PDMS.Models.Common
{
    public class Dimensions
    {
        [JsonProperty("width")]
        public MeasuringSystem Width { get; set; }

        [JsonProperty("length")]
        public MeasuringSystem Length { get; set; }
    }
}