using Newtonsoft.Json;

namespace ShawContract.Providers.PDMS.Models.Common
{
    public class MeasuringUnit
    {
        [JsonProperty("displayValue")]
        public string DisplayValue { get; set; }

        [JsonProperty("originalValue")]
        public double OriginalValue { get; set; }

        [JsonProperty("formattedValue")]
        public double FormattedValue { get; set; }

        [JsonProperty("uom")]
        public string Uom { get; set; }
    }
}