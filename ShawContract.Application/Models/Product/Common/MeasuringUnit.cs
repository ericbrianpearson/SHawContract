namespace ShawContract.Application.Models.Product.Common
{
    public class MeasuringUnit
    {
        public string DisplayValue { get; set; }
        public double OriginalValue { get; set; }
        public double FormattedValue { get; set; }
        public string Uom { get; set; }
    }
}