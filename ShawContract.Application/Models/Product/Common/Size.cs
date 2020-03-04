namespace ShawContract.Application.Models.Product.Common
{
    public class Size
    {
        public MeasuringSystem Width { get; set; }
        public MeasuringSystem Length { get; set; }
        public string ImperialDisplayValue { get; set; }
        public string MetricDisplayValue { get; set; }
    }
}