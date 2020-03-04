using Newtonsoft.Json;

namespace ShawContract.Providers.PDMS.Models.Common
{
    public class Size
    {
        [JsonProperty("width")]
        public MeasuringSystem Width { get; set; }

        [JsonProperty("length")]
        public MeasuringSystem Length { get; set; }

        [JsonProperty("imperialDisplayValue")]
        public string ImperialDisplayValue { get; set; }

        [JsonProperty("metricDisplayValue")]
        public string MetricDisplayValue { get; set; }
    }
}