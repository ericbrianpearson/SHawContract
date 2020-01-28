using System.Collections.Generic;
using Newtonsoft.Json;
using ShawContract.Providers.PDMS.Models.Common;

namespace ShawContract.Providers.PDMS.Models
{
    public class HardwoodSpecification : BaseSpecification
    {
        [JsonProperty("species")]
        public IEnumerable<string> Species { get; set; }

        [JsonProperty("edgeProfile")]
        public string EdgeProfile { get; set; }

        [JsonProperty("surfaceFinishDesc")]
        public string Finish { get; set; }

        [JsonProperty("overallThickness")]
        public MeasuringSystem OverallThickness { get; set; }

        [JsonProperty("installationGrade")]
        public string Installation { get; set; }
    }
}