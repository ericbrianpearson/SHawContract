using Newtonsoft.Json;

namespace ShawContract.Providers.PDMS.Models.Common
{
    public class Attribute
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("displayValue")]
        public string DisplayValue { get; set; }

        [JsonProperty("pdfLink")]
        public string PdfLink { get; set; }
    }
}