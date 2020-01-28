using Newtonsoft.Json;

namespace ShawContract.Providers.PDMS.Models
{
    public class RoomScene
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("thumbnailPreviewUrl")]
        public string ThumbnaulPreviewUrl { get; set; }
    }
}