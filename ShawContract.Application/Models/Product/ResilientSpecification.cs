using ShawContract.Application.Models.Product.Common;

namespace ShawContract.Application.Models.Product
{
    public class ResilientSpecification : BaseSpecification
    {
        public string Finish { get; set; }
        public MeasuringSystem OverallThickness { get; set; }
        public string Installation { get; set; }
    }
}