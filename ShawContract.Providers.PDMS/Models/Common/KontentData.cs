using System.Collections.Generic;
using Newtonsoft.Json;

namespace ShawContract.Providers.PDMS.Models
{
    public class KontentData
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("specialNotes")]
        public string SpecialNotes { get; set; }

        [JsonProperty("productSustainability")]
        public IEnumerable<MainKontentItem> Sustainability { get; set; }

        [JsonProperty("documents")]
        public IEnumerable<MainKontentItem> Documents { get; set; }

        [JsonProperty("features")]
        public IEnumerable<MainKontentItem> Features { get; set; }

        [JsonProperty("installation")]
        public IEnumerable<MainKontentItem> Installation { get; set; }

        [JsonProperty("availableRoomScenes")]
        public IEnumerable<RoomScene> AvailableRoomScenes { get; set; }
    }
}