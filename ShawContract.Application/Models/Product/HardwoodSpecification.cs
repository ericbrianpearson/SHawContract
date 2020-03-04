using System.Collections.Generic;
using ShawContract.Application.Models.Product.Common;

namespace ShawContract.Application.Models.Product
{
    public class HardwoodSpecification : BaseSpecification
    {
        public IEnumerable<string> Species { get; set; }
        public string EdgeProfile { get; set; }
        public string Finish { get; set; }
        public MeasuringSystem OverallThickness { get; set; }
        public string Installation { get; set; }
    }
}