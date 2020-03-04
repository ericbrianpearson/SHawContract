using System.Collections.Generic;

namespace ShawContract.Application.Models.Product.Common
{
    public class KontentData
    {
        public string Description { get; set; }
        public string SpecialNotes { get; set; }
        public IEnumerable<MainKontentItem> Sustainability { get; set; }
        public IEnumerable<MainKontentItem> Documents { get; set; }
        public IEnumerable<MainKontentItem> Features { get; set; }
        public IEnumerable<MainKontentItem> Installation { get; set; }
        public IEnumerable<RoomScene> AvailableRoomScenes { get; set; }
    }
}