namespace ShawContract.Application.Models
{
    public class ShoppingCartItem
    {
        public int CartItemID { get; set; }
        public string CartItemName { get; set; }
        public int SKUID { get; set; }
        public decimal TotalPrice { get; set; }
        public int TotalUnits { get; set; }
        public string Color => "Blue"; //todo: change with real color when products are ready
        public string[] SampleTypes => new string[] { "Cut Swatch", "Cut Swatch 2" }; //todo: change with real sample types when products are readdy
    }
}