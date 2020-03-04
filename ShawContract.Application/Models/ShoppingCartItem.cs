namespace ShawContract.Application.Models
{
    public class ShoppingCartItem
    {
        public int CartItemID { get; set; }    
        public int SKUID { get; set; }
        public int SKUIDColor { get; set; }
        public string ProductType { get; set; }
        public string ItemName { get; set; }
        public string ItemNumber { get; set; }
        public string ColorName { get; set; }
        public string ColorNumber { get; set; }
        public int TotalUnits { get; set; }
        public string ImageUrl { get; set; }
        public string[] SampleTypes => new string[] { "Cut Swatch", "Cut Swatch 2" }; //todo: change with real sample types when products are readdy
    }
}