using ShawContract.Application.Models.Product.Common;

namespace ShawContract.Application.Models.Product
{
    public class CarpetSpecification : BaseSpecification
    {
        public string Backing { get; set; }
        public string Fiber { get; set; }
        public MeasuringSystem TuftedWeight { get; set; }
    }
}