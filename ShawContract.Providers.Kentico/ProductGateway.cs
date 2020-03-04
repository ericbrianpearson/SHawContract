using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using CMS.DocumentEngine.Types.ShawContract;
using CMS.Ecommerce;
using Newtonsoft.Json;
using ShawContract.Application.Contracts.Gateways;
using ShawContract.Application.Models.Product;
using ShawContract.Application.Models.Product.Common;
using ShawContract.Providers.Kentico.PageHandler;

namespace ShawContract.Providers.Kentico
{
    public class ProductGateway : IProductGateway
    {
        private List<string> coreColumns = new List<string>
        {
            "NodeSKUID",
            "Colors",
            "Collection",
            "StyleName",
           "StyleNumber",
            "ProductSize",
            "Construction",
            "ProductType",
            "InventoryType",
            "Warranty",
            "WarrantyLink",
            "LinkFullSpecs",
            "AreaPerCarton",
            "Sustainability",
            "FeatureImage",
            "KontentData",
            "RecommendedInstallationMethods",
            "SimilarProducts"
    };

        private readonly JsonSerializerSettings _jsonSettings;
        private IPageContentHandler PageContentHandler { get; }

        public ProductGateway(IPageContentHandler pageContentHandler)
        {
            this.PageContentHandler = pageContentHandler;
            this._jsonSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };
        }

        public IEnumerable<CollectionProduct> GetSimilarProducts(IEnumerable<string> items , string inventoryType)
        {
            List<string> columns = new List<string>
             {
                 "StyleName",
                 "StyleNumber",
                 "FeatureImage"
             };

            var products = new List<CollectionProduct>();

            switch (inventoryType.ToLower())
            {
                case "carpet":
                    AddCarpetSimilarProducts(products, items, columns);
                    break;

                case "rug":
                    AddRugSimilarProducts(products, items, columns);
                    break;


                case "resilient":
                    AddResilientSimilarProducts(products, items, columns);
                    break;

                case "hardwood":
                    AddHardwoodSimilarProducts(products, items, columns);
                    break;

                default:
                    return null;
            }
            return products;
        }

       
        public IEnumerable<CollectionProduct> GetCollectionProducts(string collectionName, string inventoryType)
        {
            List<string> columns = new List<string>
             {
                 "Collection",
                 "StyleName",
                 "StyleNumber",
                 "FeatureImage"
             };

            switch (inventoryType.ToLower())
            {
                case "carpet":
                    return this.PageContentHandler.GetPages<Carpet>()
                        .AddColumns(columns)
                        .Where(c => c.Collection == collectionName)
                        .Select(p => new CollectionProduct
                        {
                            ImageUrl = p.FeatureImage,
                            StyleName = p.StyleName,
                            StyleNumber = p.StyleNumber
                        })
                        .ToList();

                case "rug":
                    return this.PageContentHandler.GetPages<Rug>()
                       .AddColumns(columns)
                       .Where(c => c.Collection == collectionName)
                       .Select(p => new CollectionProduct
                       {
                           ImageUrl = p.FeatureImage,
                           StyleName = p.StyleName,
                           StyleNumber = p.StyleNumber
                       })
                       .ToList();


                case "resilient":
                    return this.PageContentHandler.GetPages<Resilient>()
                        .AddColumns(columns)
                        .Where(c => c.Collection == collectionName)
                        .Select(p => new CollectionProduct
                        {
                            ImageUrl = p.FeatureImage,
                            StyleName = p.StyleName,
                            StyleNumber = p.StyleNumber
                        })
                        .ToList();

                case "hardwood":
                    return this.PageContentHandler.GetPages<Hardwood>()
                        .AddColumns(columns)
                        .Where(c => c.Collection == collectionName)
                        .Select(p => new CollectionProduct
                        {
                            ImageUrl = p.FeatureImage,
                            StyleName = p.StyleName,
                            StyleNumber = p.StyleNumber
                        })
                        .ToList();

                default:
                    return null;
            }
        }

        public BaseSpecification GetProductPage(string inventoryType, string nodeAlias)
        {
            switch (inventoryType.ToLower())
            {
                case "carpet":
                    var carpetColumns = new List<string>(coreColumns);
                    carpetColumns.Add("Backing");
                    carpetColumns.Add("Fiber");
                    carpetColumns.Add("TuftedWeight");


                    var carpetDocument = this.PageContentHandler.GetPage<Carpet>(nodeAlias)
                        .AddColumns(carpetColumns)
                        .FirstOrDefault();

                    List<ProductVariant> carpetVariants = this.PageContentHandler.GetVariants(carpetDocument.NodeSKUID);

                    var carpet = MapCarpetDocument(carpetDocument);
                    MapVariants(carpet as BaseSpecification, carpetVariants);
                    return carpet as BaseSpecification;

                case "rug":
                    var rugColumns = new List<string>(coreColumns);
                    rugColumns.Add("Backing");
                    rugColumns.Add("Fiber");
                    rugColumns.Add("TuftedWeight");

                    var rugDocument = this.PageContentHandler.GetPage<Rug>(nodeAlias)
                        .AddColumns(rugColumns)
                        .FirstOrDefault();

                    List<ProductVariant> rugVariants = this.PageContentHandler.GetVariants(rugDocument.NodeSKUID);

                    var rug = MapRugDocument(rugDocument);
                    MapVariants(rug as BaseSpecification, rugVariants);
                    return rug as BaseSpecification;

                case "resilient":
                    var resilientColumns = new List<string>(coreColumns);
                    resilientColumns.Add("Finish");
                    resilientColumns.Add("OverallThickness");
                    resilientColumns.Add("Installation");

                    var resilientDocument = this.PageContentHandler.GetPage<Resilient>(nodeAlias)
                        .AddColumns(resilientColumns)
                        .FirstOrDefault();

                    List<ProductVariant> resilientVariants = this.PageContentHandler.GetVariants(resilientDocument.NodeSKUID);

                    var resilient = MapResilientDocument(resilientDocument);
                    MapVariants(resilient as BaseSpecification, resilientVariants);
                    return resilient as BaseSpecification;

                case "hardwood":
                    var hardwoodColumns = new List<string>(coreColumns);
                    hardwoodColumns.Add("Finish");
                    hardwoodColumns.Add("OverallThickness");
                    hardwoodColumns.Add("Installation");
                    hardwoodColumns.Add("Species");
                    hardwoodColumns.Add("EdgeProfile");

                    var hardwoodDocument = this.PageContentHandler.GetPage<Hardwood>(nodeAlias)
                        .AddColumns("DocumentID")
                        .FirstOrDefault();

                    List<ProductVariant> hardwoodVariants = this.PageContentHandler.GetVariants(hardwoodDocument.NodeSKUID);


                    var hardwood = MapHardwoodDocument(hardwoodDocument);
                    MapVariants(hardwood as BaseSpecification, hardwoodVariants);
                    return hardwood as BaseSpecification;

                default:
                    return null;
            }
        }

        private void MapVariants(BaseSpecification baseSpecification, List<ProductVariant> variants)
        {
            foreach (var color in baseSpecification.Colors)
            {
                var id = variants.FirstOrDefault(v => v.Variant.SKUName.Contains(color.ColorName)).Variant.SKUID;
                color.SKUID = id;
            }
        }

        private HardwoodSpecification MapHardwoodDocument(Hardwood hardwoodDocument)
        {
            return new HardwoodSpecification
            {
                SKUID = hardwoodDocument.SKU.SKUID,
                Colors = JsonConvert.DeserializeObject<List<Color>>(hardwoodDocument.Colors, _jsonSettings),
                Collection = hardwoodDocument.Collection,
                StyleName = hardwoodDocument.StyleName,
                StyleNumber = hardwoodDocument.StyleNumber,
                ProductSize = JsonConvert.DeserializeObject<Size>(hardwoodDocument.ProductSize, _jsonSettings),
                Construction = hardwoodDocument.Construction,
                ProductType = hardwoodDocument.ProductType,
                InventoryType = hardwoodDocument.InventoryType,
                Warranty = JsonConvert.DeserializeObject<List<string>>(hardwoodDocument.Warranty, _jsonSettings),
                WarrantyLink = hardwoodDocument.WarrantyLink,
                LinkToFullSpec = hardwoodDocument.LinkFullSpecs,
                FeatureImage = hardwoodDocument.FeatureImage,
                AreaPerCarton = JsonConvert.DeserializeObject<MeasuringSystem>(hardwoodDocument.AreaPerCarton, _jsonSettings),
                Sustainability = JsonConvert.DeserializeObject<List<ProductAttribute>>(hardwoodDocument.Sustainability, _jsonSettings),
                KontentData = JsonConvert.DeserializeObject<KontentData>(hardwoodDocument.KontentData, _jsonSettings),
                RecommendedInstallationMethods = JsonConvert.DeserializeObject<List<string>>(hardwoodDocument.RecommendedInstallationMethods, _jsonSettings),
                SimilarProducts = JsonConvert.DeserializeObject<List<string>>(hardwoodDocument.SimilarProducts, _jsonSettings),
                Finish = hardwoodDocument.Finish,
                Installation = hardwoodDocument.Installation,
                EdgeProfile = hardwoodDocument.EdgeProfile,
                OverallThickness = JsonConvert.DeserializeObject<MeasuringSystem>(hardwoodDocument.OverallThickness, _jsonSettings),
                Species = JsonConvert.DeserializeObject<List<string>>(hardwoodDocument.Species, _jsonSettings)
            };
        }

        private ResilientSpecification MapResilientDocument(Resilient resilientDocument)
        {
            return new ResilientSpecification
            {
                SKUID = resilientDocument.SKU.SKUID,
                Colors = JsonConvert.DeserializeObject<List<Color>>(resilientDocument.Colors, _jsonSettings),
                Collection = resilientDocument.Collection,
                StyleName = resilientDocument.StyleName,
                StyleNumber = resilientDocument.StyleNumber,
                FeatureImage = resilientDocument.FeatureImage,
                ProductSize = JsonConvert.DeserializeObject<Size>(resilientDocument.ProductSize, _jsonSettings),
                Construction = resilientDocument.Construction,
                ProductType = resilientDocument.ProductType,
                InventoryType = resilientDocument.InventoryType,
                Warranty = JsonConvert.DeserializeObject<List<string>>(resilientDocument.Warranty, _jsonSettings),
                WarrantyLink = resilientDocument.WarrantyLink,
                LinkToFullSpec = resilientDocument.LinkFullSpecs,
                AreaPerCarton = JsonConvert.DeserializeObject<MeasuringSystem>(resilientDocument.AreaPerCarton, _jsonSettings),
                Sustainability = JsonConvert.DeserializeObject<List<ProductAttribute>>(resilientDocument.Sustainability, _jsonSettings),
                KontentData = JsonConvert.DeserializeObject<KontentData>(resilientDocument.KontentData, _jsonSettings),
                RecommendedInstallationMethods = JsonConvert.DeserializeObject<List<string>>(resilientDocument.RecommendedInstallationMethods, _jsonSettings),
                SimilarProducts = JsonConvert.DeserializeObject<List<string>>(resilientDocument.SimilarProducts, _jsonSettings),
                Finish = resilientDocument.Finish,
                Installation = resilientDocument.Installation,
                OverallThickness = JsonConvert.DeserializeObject<MeasuringSystem>(resilientDocument.OverallThickness, _jsonSettings)
            };
        }

        private RugSpecification MapRugDocument(Rug rugDocument)
        {
            return new RugSpecification
            {
                SKUID = rugDocument.SKU.SKUID,
                Colors = JsonConvert.DeserializeObject<List<Color>>(rugDocument.Colors, _jsonSettings),
                Collection = rugDocument.Collection,
                StyleName = rugDocument.StyleName,
                StyleNumber = rugDocument.StyleNumber,
                ProductSize = JsonConvert.DeserializeObject<Size>(rugDocument.ProductSize, _jsonSettings),
                FeatureImage = rugDocument.FeatureImage,
                Construction = rugDocument.Construction,
                ProductType = rugDocument.ProductType,
                InventoryType = rugDocument.InventoryType,
                Warranty = JsonConvert.DeserializeObject<List<string>>(rugDocument.Warranty, _jsonSettings),
                WarrantyLink = rugDocument.WarrantyLink,
                LinkToFullSpec = rugDocument.LinkFullSpecs,
                AreaPerCarton = JsonConvert.DeserializeObject<MeasuringSystem>(rugDocument.AreaPerCarton, _jsonSettings),
                Sustainability = JsonConvert.DeserializeObject<List<ProductAttribute>>(rugDocument.Sustainability, _jsonSettings),
                KontentData = JsonConvert.DeserializeObject<KontentData>(rugDocument.KontentData, _jsonSettings),
                RecommendedInstallationMethods = JsonConvert.DeserializeObject<List<string>>(rugDocument.RecommendedInstallationMethods, _jsonSettings),
                SimilarProducts = JsonConvert.DeserializeObject<List<string>>(rugDocument.SimilarProducts, _jsonSettings),
                Backing = rugDocument.Backing,
                Fiber = rugDocument.Fiber,
                TuftedWeight = JsonConvert.DeserializeObject<MeasuringSystem>(rugDocument.TuftedWeight, _jsonSettings)
            };
        }

        private CarpetSpecification MapCarpetDocument(Carpet carpetDocument)
        {
            return new CarpetSpecification
            {
                SKUID = carpetDocument.SKU.SKUID,
                Colors = JsonConvert.DeserializeObject<List<Color>>(carpetDocument.Colors, _jsonSettings),
                Collection = carpetDocument.Collection,
                StyleName = carpetDocument.StyleName,
                StyleNumber = carpetDocument.StyleNumber,
                ProductSize = JsonConvert.DeserializeObject<Size>(carpetDocument.ProductSize, _jsonSettings),
                FeatureImage = carpetDocument.FeatureImage,
                Construction = carpetDocument.Construction,
                ProductType = carpetDocument.ProductType,
                InventoryType = carpetDocument.InventoryType,
                Warranty = JsonConvert.DeserializeObject<List<string>>(carpetDocument.Warranty, _jsonSettings),
                WarrantyLink = carpetDocument.WarrantyLink,
                LinkToFullSpec = carpetDocument.LinkFullSpecs,
                AreaPerCarton = JsonConvert.DeserializeObject<MeasuringSystem>(carpetDocument.AreaPerCarton, _jsonSettings),
                Sustainability = JsonConvert.DeserializeObject<List<ProductAttribute>>(carpetDocument.Sustainability, _jsonSettings),
                KontentData = JsonConvert.DeserializeObject<KontentData>(carpetDocument.KontentData, _jsonSettings),
                RecommendedInstallationMethods = JsonConvert.DeserializeObject<List<string>>(carpetDocument.RecommendedInstallationMethods, _jsonSettings),
                SimilarProducts = JsonConvert.DeserializeObject<List<string>>(carpetDocument.SimilarProducts, _jsonSettings),
                Backing = carpetDocument.Backing,
                Fiber = carpetDocument.Fiber,
                TuftedWeight = JsonConvert.DeserializeObject<MeasuringSystem>(carpetDocument.TuftedWeight, _jsonSettings)
            };
        }

        private void AddCarpetSimilarProducts(List<CollectionProduct> products, IEnumerable<string> items, List<string> columns)
        {
            foreach (var item in items)
            {
                var productPage = PageContentHandler.GetPages<Carpet>()
                            .AddColumns(columns)
                            .Where(c => c.StyleNumber == item)
                            .FirstOrDefault();

                if (productPage != null)
                {
                    products.Add(new CollectionProduct
                    {
                        ImageUrl = productPage.FeatureImage,
                        StyleName = productPage.StyleName,
                        StyleNumber = productPage.StyleNumber
                    });
                }
            }
        }

        private void AddResilientSimilarProducts(List<CollectionProduct> products, IEnumerable<string> items, List<string> columns)
        {
            foreach (var item in items)
            {
                var productPage = PageContentHandler.GetPages<Resilient>()
                            .AddColumns(columns)
                            .Where(c => c.StyleNumber == item)
                            .FirstOrDefault();

                if (productPage != null)
                {
                    products.Add(new CollectionProduct
                    {
                        ImageUrl = productPage.FeatureImage,
                        StyleName = productPage.StyleName,
                        StyleNumber = productPage.StyleNumber
                    });
                }
            }
        }

        private void AddHardwoodSimilarProducts(List<CollectionProduct> products, IEnumerable<string> items, List<string> columns)
        {
            foreach (var item in items)
            {
                var productPage = PageContentHandler.GetPages<Hardwood>()
                            .AddColumns(columns)
                            .Where(c => c.StyleNumber == item)
                            .FirstOrDefault();

                if (productPage != null)
                {
                    products.Add(new CollectionProduct
                    {
                        ImageUrl = productPage.FeatureImage,
                        StyleName = productPage.StyleName,
                        StyleNumber = productPage.StyleNumber
                    });
                }
            }
        }

        private void AddRugSimilarProducts(List<CollectionProduct> products, IEnumerable<string> items, List<string> columns)
        {
            foreach (var item in items)
            {
                var productPage = PageContentHandler.GetPages<Rug>()
                            .AddColumns(columns)
                            .Where(c => c.StyleNumber == item)
                            .FirstOrDefault();

                if (productPage != null)
                {
                    products.Add(new CollectionProduct
                    {
                        ImageUrl = productPage.FeatureImage,
                        StyleName = productPage.StyleName,
                        StyleNumber = productPage.StyleNumber
                    });
                }
            }
        }
    }
}