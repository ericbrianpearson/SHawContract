using Newtonsoft.Json;
using ShawContract.Providers.PDMS.Models.Common;

namespace ShawContract.Providers.PDMS.Models
{
    public class ResilientSpecification : BaseSpecification
    {
        [JsonProperty("surfaceFinishDesc")]
        public string Finish { get; set; }

        [JsonProperty("overallThickness")]
        public MeasuringSystem OverallThickness { get; set; }

        [JsonProperty("installationGrade")]
        public string Installation { get; set; }

        [JsonProperty("actualDimensions")]
        public Size ActualDimensions { get; set; }

        [JsonProperty("inventorySubType")]
        public string ProductSubType { get; set; }
    }
}