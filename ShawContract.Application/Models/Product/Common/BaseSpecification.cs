using System.Collections.Generic;

namespace ShawContract.Application.Models.Product.Common
{
    public class BaseSpecification
    {
        public int SKUID { get; set; }
        public IEnumerable<Color> Colors { get; set; }
        public string Collection { get; set; }
        public string StyleName { get; set; }
        public string StyleNumber { get; set; }
        public Size ProductSize { get; set; }
        public string Construction { get; set; }
        public string ProductType { get; set; }
        public string InventoryType { get; set; }
        public IEnumerable<string> Warranty { get; set; }
        public string WarrantyLink { get; set; }
        public string LinkToFullSpec { get; set; }
        public string FeatureImage { get; set; }
        public MeasuringSystem AreaPerCarton { get; set; }
        public IEnumerable<ProductAttribute> Sustainability { get; set; }
        public KontentData KontentData { get; set; }
        public IEnumerable<string> RecommendedInstallationMethods { get; set; }

        public IEnumerable<string> SimilarProducts { get; set; }
    }
}