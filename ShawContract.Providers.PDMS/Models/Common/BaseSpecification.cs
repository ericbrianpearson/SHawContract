using System.Collections.Generic;
using Newtonsoft.Json;
using ShawContract.Providers.PDMS.Models.Common;

namespace ShawContract.Providers.PDMS.Models
{
    public class BaseSpecification
    {
        [JsonProperty("colors")]
        public IEnumerable<Color> Colors { get; set; }

        [JsonProperty("collection")]
        public string Collection { get; set; }

        [JsonProperty("sellingStyleName")]
        public string StyleName { get; set; }

        [JsonProperty("sellingStyleNumber")]
        public string StyleNumber { get; set; }

        [JsonProperty("productSize")]
        public MeasuringSystem ProductSize { get; set; }

        [JsonProperty("construction")]
        public string Construction { get; set; }

        [JsonProperty("productTypeDesc")]
        public string ProductType { get; set; }

        [JsonProperty("inventoryType")]
        public string InventoryType { get; set; }

        [JsonProperty("warranties")]
        public IEnumerable<string> Warranty { get; set; }

        [JsonProperty("combinedWarrantyLink")]
        public string WarrantyLink { get; set; }

        [JsonProperty("pdmsLink")]
        public string LinkToFullSpec { get; set; }

        [JsonProperty("areaPerCarton")]
        public MeasuringSystem AreaPerCarton { get; set; }

        [JsonProperty("attributes")]
        public IEnumerable<Attribute> Sustainability { get; set; }

        [JsonProperty("kenticoCloudData")]
        public KontentData KontentData { get; set; }
    }
}