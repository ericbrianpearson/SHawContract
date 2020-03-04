namespace ShawContract.Application.Models
{
    public class OrderItem
    {
        public string PictureUrl { get; set; }
        public int SKUID { get; set; }
        public string StyleName { get; set; } //Item Name
        public string StyleNumber { get; set; } //ItemNumber
        public string ColorName { get; set; } //color name
        public string ColorNumber { get; set; } //color number
        public decimal Quantity { get; set; } //OrderItemUnitCount
    }
}