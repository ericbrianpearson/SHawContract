using Newtonsoft.Json;

namespace ShawContract.Providers.PDMS.Models.Common
{
    public class MeasuringSystem
    {
        [JsonProperty("imperial")]
        public MeasuringUnit Imperial { get; set; }

        [JsonProperty("metric")]
        public MeasuringUnit Metric { get; set; }
    }
}