using Newtonsoft.Json;
using ShawContract.Providers.PDMS.Models.Common;

namespace ShawContract.Providers.PDMS.Models
{
    public class RugSpecification : BaseSpecification
    {
        [JsonProperty("secondaryBacking")]
        public string Backing { get; set; }

        [JsonProperty("fiber")]
        public string Fiber { get; set; }

        [JsonProperty("tuftedWeight")]
        public MeasuringSystem TuftedWeight { get; set; }

        [JsonProperty("combinedWarrantyLink")]
        public string CombinedWarantyLink { get; set; }
    }
}