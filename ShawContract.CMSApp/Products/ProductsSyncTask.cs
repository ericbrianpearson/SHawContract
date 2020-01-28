using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS;
using CMS.DocumentEngine;
using CMS.Ecommerce;
using CMS.EventLog;
using CMS.Localization;
using CMS.Membership;
using CMS.Scheduler;
using CMS.SiteProvider;
using Newtonsoft.Json;
using ShawContract.Providers.PDMS;
using ShawContract.Providers.PDMS.Models;
using ShawContract.Providers.PDMS.Models.Common;

[assembly: RegisterCustomClass("ShawContract.CMSApp.Products.ProductSyncTask", typeof(ShawContract.CMSApp.Products.ProductsSyncTask))]

namespace ShawContract.CMSApp.Products
{
    public class ProductsSyncTask : ITask
    {
        private readonly JsonSerializerSettings _jsonSettings;
        private ProductGateway ProductGateway { get; }

        public ProductsSyncTask()
        {
            ProductGateway = new ProductGateway(new PDMSConfiguration());

            _jsonSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };
        }

        /// <summary>
        /// Executes the task.
        /// </summary>
        /// <param name="task">Info object representing the scheduled task</param>
        public string Execute(TaskInfo task)
        {
            string details = "Custom scheduled task executed. Task data: " + task.TaskData;

            // Logs the execution of the task in the event log
            EventLogProvider.LogInformation("ProductsSyncTask", "Execute", details);

            try
            {
                EventLogProvider.LogInformation("ProductsSyncTask", "Execute", "Importing Carpet Products");
                var carpets = ProductGateway.GetProductSpecificationsAsync<CarpetSpecification>(ProductType.Carpet.ToString()).GetAwaiter().GetResult();

                if (carpets != null && carpets.Count() > 0)
                {
                    CreateAndUpdateProduct(carpets);
                }

                EventLogProvider.LogInformation("ProductsSyncTask", "Execute", "Importing Rug Products");
                // var resilient = ProductGateway.GetProductSpecificationsAsync<ResilientSpecification>(ProductType.Resilient.ToString()).GetAwaiter().GetResult();

                EventLogProvider.LogInformation("ProductsSyncTask", "Execute", "Importing Resilient Products");

                var resilients = ProductGateway.GetProductSpecificationsAsync<ResilientSpecification>(ProductType.Resilient.ToString()).GetAwaiter().GetResult();

                if (resilients != null && resilients.Count() > 0)
                {
                    CreateAndUpdateProduct(resilients);
                }

                EventLogProvider.LogInformation("ProductsSyncTask", "Execute", "Importing Hardwood Products");

                var hardwoods = ProductGateway.GetProductSpecificationsAsync<HardwoodSpecification>(ProductType.Hardwood.ToString()).GetAwaiter().GetResult();

                if (hardwoods != null && hardwoods.Count() > 0)
                {
                    CreateAndUpdateProduct(hardwoods);
                }
            }
            catch (Exception ex)
            {
                EventLogProvider.LogException("ProductsSyncTask", "Execute", ex);
                throw ex;
            }
            // Returns a null value to indicate that the task executed successfully
            // Return an error message string with details in cases where the execution fails
            return null;
        }

        private void CreateAndUpdateProduct(IEnumerable<BaseSpecification> products)
        {
            foreach (var product in products)
            {
                try
                {
                    var productSKU = SKUInfoProvider.GetSKUs()
                   .FirstOrDefault(sk => sk.SKUName == product.StyleName && sk.SKUNumber == product.StyleNumber);

                    if (productSKU == null)
                    {
                        productSKU = CreateProductSKU(product.StyleName, product.StyleNumber, 0);
                    }
                    CreateAndUpdateProductDocument(product, productSKU);
                    AddCategoryToProduct(productSKU.SKUID);
                    AllowOptionForProduct(productSKU.SKUID);
                    CreateAndUpdateVariants(productSKU.SKUID, product.Colors);
                }
                catch (Exception ex)
                {
                    EventLogProvider.LogException("ProductsSyncTask", "Execute", ex, additionalMessage: "Failed to import/update product: " + product.InventoryType + " - " + product.StyleNumber);
                }
            }
        }

        /// <summary>
        /// Creates new product SKU
        /// </summary>
        /// <param name="styleName"></param>
        /// <param name="styleNumber"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        private SKUInfo CreateProductSKU(string styleName, string styleNumber, decimal price)
        {
            // Create new product object
            SKUInfo newProduct = new SKUInfo
            {
                SKUName = styleName,
                SKUNumber = styleNumber,
                SKUPrice = price,
                SKUEnabled = true,
                SKUSiteID = SiteContext.CurrentSiteID
            };

            // Create the product
            SKUInfoProvider.SetSKUInfo(newProduct);

            return newProduct;
        }

        private int CreateAndUpdateProductDocument(BaseSpecification product, SKUInfo productSKU)
        {
            TreeProvider tree = new TreeProvider(MembershipContext.AuthenticatedUser);

            // Get the parent document
            TreeNode parent = tree.SelectSingleNode(SiteContext.CurrentSiteName, "/Products", TreeProvider.ALL_CULTURES, true);

            if ((parent != null) && (productSKU != null))
            {
                switch ((product as BaseSpecification).InventoryType)
                {
                    case "Carpet":
                        CreateAndUpdateCarpetDocument(productSKU.SKUID, product as CarpetSpecification, tree, parent);
                        return productSKU.SKUID;

                    case "Rug":
                        CreateAndUpdateRugDocument(productSKU.SKUID, product as RugSpecification, tree, parent);
                        return productSKU.SKUID;

                    case "Resilient":
                        CreateAndUpdateResilientDocument(productSKU.SKUID, product as ResilientSpecification, tree, parent);
                        return productSKU.SKUID;

                    case "Hardwood":
                        CreateAndUpdateHardwoodDocument(productSKU.SKUID, product as HardwoodSpecification, tree, parent);
                        return productSKU.SKUID;

                    default:
                        return -1;
                }
            }

            return -1;
        }

        private void CreateAndUpdateCarpetDocument(int skuID, CarpetSpecification carpet, TreeProvider tree, TreeNode parent)
        {
            List<TreeNode> nodes = tree.SelectNodes("ShawContract.Carpet")
                .OnCurrentSite()
                .CombineWithDefaultCulture()
                .ToList();

            SKUTreeNode node = (SKUTreeNode)nodes.FirstOrDefault(nd => nd.NodeSKUID == skuID);

            if (node == null)
            {
                node = (SKUTreeNode)TreeNode.New("ShawContract.Carpet", tree);
                CreateAndUpdateBaseNode(carpet, node);

                node.SetValue("Backing", carpet.Backing);
                node.SetValue("Fiber", carpet.Fiber);
                node.SetValue("TuftedWeight", JsonConvert.SerializeObject(carpet.TuftedWeight, _jsonSettings));
                node.SetValue("CombinedWarantyLink", carpet.CombinedWarantyLink);

                node.NodeSKUID = skuID;

                node.Insert(parent);
                return;
            }

            CreateAndUpdateBaseNode(carpet, node);

            node.SetValue("Backing", carpet.Backing);
            node.SetValue("Fiber", carpet.Fiber);
            node.SetValue("TuftedWeight", JsonConvert.SerializeObject(carpet.TuftedWeight, _jsonSettings));
            node.SetValue("CombinedWarantyLink", carpet.CombinedWarantyLink);

            DocumentHelper.UpdateDocument(node, tree);
        }

        private void CreateAndUpdateRugDocument(int skuID, RugSpecification rug, TreeProvider tree, TreeNode parent)
        {
            // Gets the product page
            List<TreeNode> nodes = tree.SelectNodes("ShawContract.Rug")
                  .OnCurrentSite()
                  .CombineWithDefaultCulture()
                  .ToList();

            SKUTreeNode node = (SKUTreeNode)nodes.FirstOrDefault(nd => nd.NodeSKUID == skuID);

            if (node == null)
            {
                node = (SKUTreeNode)TreeNode.New("ShawContract.Rug", tree);
                CreateAndUpdateBaseNode(rug, node);

                node.SetValue("Backing", rug.Backing);
                node.SetValue("Fiber", rug.Fiber);
                node.SetValue("TuftedWeight", JsonConvert.SerializeObject(rug.TuftedWeight, _jsonSettings));
                node.SetValue("CombinedWarantyLink", rug.CombinedWarantyLink);

                node.NodeSKUID = skuID;

                node.Insert(parent);
                return;
            }

            CreateAndUpdateBaseNode(rug, node);

            node.SetValue("Backing", rug.Backing);
            node.SetValue("Fiber", rug.Fiber);
            node.SetValue("TuftedWeight", JsonConvert.SerializeObject(rug.TuftedWeight, _jsonSettings));
            node.SetValue("CombinedWarantyLink", rug.CombinedWarantyLink);

            DocumentHelper.UpdateDocument(node, tree);
        }

        private void CreateAndUpdateResilientDocument(int skuID, ResilientSpecification resilient, TreeProvider tree, TreeNode parent)
        {
            // Gets the product page
            List<TreeNode> nodes = tree.SelectNodes("ShawContract.Resilient")
                  .OnCurrentSite()
                  .CombineWithDefaultCulture()
                  .ToList();

            SKUTreeNode node = (SKUTreeNode)nodes.FirstOrDefault(nd => nd.NodeSKUID == skuID);

            if (node == null)
            {
                node = (SKUTreeNode)TreeNode.New("ShawContract.Resilient", tree);
                CreateAndUpdateBaseNode(resilient, node);

                node.SetValue("Finish", resilient.Finish);
                node.SetValue("OverallThickness", JsonConvert.SerializeObject(resilient.OverallThickness, _jsonSettings));
                node.SetValue("Installation", JsonConvert.SerializeObject(resilient.Installation, _jsonSettings));

                node.NodeSKUID = skuID;

                node.Insert(parent);
                return;
            }

            CreateAndUpdateBaseNode(resilient, node);

            node.SetValue("Finish", resilient.Finish);
            node.SetValue("OverallThickness", JsonConvert.SerializeObject(resilient.OverallThickness, _jsonSettings));
            node.SetValue("Installation", JsonConvert.SerializeObject(resilient.Installation, _jsonSettings));

            DocumentHelper.UpdateDocument(node, tree);
        }

        private void CreateAndUpdateHardwoodDocument(int skuID, HardwoodSpecification hardwood, TreeProvider tree, TreeNode parent)
        {
            List<TreeNode> nodes = tree.SelectNodes("ShawContract.Hardwood")
                 .OnCurrentSite()
                 .CombineWithDefaultCulture()
                 .ToList();

            SKUTreeNode node = (SKUTreeNode)nodes.FirstOrDefault(nd => nd.NodeSKUID == skuID);

            if (node == null)
            {
                node = (SKUTreeNode)TreeNode.New("ShawContract.Hardwood", tree);
                CreateAndUpdateBaseNode(hardwood, node);

                node.SetValue("Species", JsonConvert.SerializeObject(hardwood.Species, _jsonSettings));
                node.SetValue("EdgeProfile", hardwood.EdgeProfile);
                node.SetValue("Finish", hardwood.Finish);
                node.SetValue("OverallThickness", JsonConvert.SerializeObject(hardwood.OverallThickness, _jsonSettings));
                node.SetValue("Installation", JsonConvert.SerializeObject(hardwood.Installation, _jsonSettings));

                node.NodeSKUID = skuID;

                node.Insert(parent);
                return;
            }
            CreateAndUpdateBaseNode(hardwood, node);

            node.SetValue("Species", JsonConvert.SerializeObject(hardwood.Species, _jsonSettings));
            node.SetValue("EdgeProfile", hardwood.EdgeProfile);
            node.SetValue("Finish", hardwood.Finish);
            node.SetValue("OverallThickness", JsonConvert.SerializeObject(hardwood.OverallThickness, _jsonSettings));
            node.SetValue("Installation", JsonConvert.SerializeObject(hardwood.Installation, _jsonSettings));

            DocumentHelper.UpdateDocument(node, tree);
        }

        private void CreateAndUpdateBaseNode(BaseSpecification baseProduct, SKUTreeNode node)
        {
            // Set the document properties
            node.DocumentName = baseProduct.StyleName;
            node.DocumentSKUName = baseProduct.StyleName;
            node.DocumentCulture = LocalizationContext.PreferredCultureCode;
            node.SetValue("Colors", JsonConvert.SerializeObject(baseProduct.Colors, _jsonSettings));
            node.SetValue("Collection", baseProduct.Collection);
            node.SetValue("StyleName", baseProduct.StyleName);
            node.SetValue("StyleNumber", baseProduct.StyleNumber);
            node.SetValue("ProductSize", JsonConvert.SerializeObject(baseProduct.ProductSize, _jsonSettings));
            node.SetValue("Construction", baseProduct.Construction);
            node.SetValue("ProductType", baseProduct.ProductType);
            node.SetValue("InventoryType", baseProduct.InventoryType);
            node.SetValue("Warranty", JsonConvert.SerializeObject(baseProduct.Warranty, _jsonSettings));
            node.SetValue("WarrantyLink", baseProduct.WarrantyLink);
            node.SetValue("LinkFullSpecs", baseProduct.LinkToFullSpec);
            node.SetValue("AreaPerCarton", JsonConvert.SerializeObject(baseProduct.AreaPerCarton, _jsonSettings));
            node.SetValue("Sustainability", JsonConvert.SerializeObject(baseProduct.Sustainability, _jsonSettings));
            node.SetValue("KontentData", JsonConvert.SerializeObject(baseProduct.KontentData, _jsonSettings));
        }

        //add the product option category to product
        private int AddCategoryToProduct(int skuID)
        {
            // Get the option category
            OptionCategoryInfo category = OptionCategoryInfoProvider.GetOptionCategoryInfo("Color", SiteContext.CurrentSiteName);

            if (category != null)
            {
                // Add category to product
                SKUOptionCategoryInfoProvider.AddOptionCategoryToSKU(category.CategoryID, skuID);

                return category.CategoryID;
            }

            return -1;
        }

        //add the product option to sku
        private bool AllowOptionForProduct(int productSkuID)
        {
            // List of options IDs
            List<int> optionIds = new List<int>();

            // Get the data
            var option = SKUInfoProvider.GetSKUs()
                               .WhereStartsWith("SKUName", "Color")
                               .WhereNotNull("SKUOptionCategoryID")
                               .FirstOrDefault();

            // Get the option
            if (option != null)
            {
                optionIds.Add(option.SKUID);
            }

            // Get the option category
            OptionCategoryInfo category = OptionCategoryInfoProvider.GetOptionCategoryInfo("Color", SiteContext.CurrentSiteName);

            if ((option != null) && (category != null))
            {
                // Allow options for product
                ProductHelper.AllowOptions(productSkuID, category.CategoryID, optionIds);

                return true;
            }

            return false;
        }

        //create a variant
        private void CreateAndUpdateVariants(int productSkuID, IEnumerable<Color> colors)
        {
            if (colors == null)
            {
                return;
            }
            OptionCategoryInfo category = OptionCategoryInfoProvider.GetOptionCategoryInfo("Color", SiteContext.CurrentSiteName);

            // List of categories
            List<int> categoryIDs = new List<int>();

            categoryIDs.Add(category.CategoryID);

            List<int> variantIDs = new List<int>();

            foreach (var color in colors)
            {
                var colorSKU = SKUInfoProvider.GetSKUs()
                    .FirstOrDefault(sk => sk.SKUNumber == color.ColorNumber && sk.SKUName == color.ColorName);

                if (colorSKU == null)
                {
                    colorSKU = new SKUInfo
                    {
                        SKUName = color.ColorName,
                        SKUNumber = color.ColorNumber,
                        SKUPrice = 0,
                        SKUEnabled = true,
                        SKUOptionCategoryID = category.CategoryID,
                        SKUSiteID = SiteContext.CurrentSiteID,
                        SKUProductType = SKUProductTypeEnum.Product
                    };
                    SKUInfoProvider.SetSKUInfo(colorSKU);
                }

                variantIDs.Add(colorSKU.SKUID);
            }

            //checks what options need to be removed from the product
            var allOptions = SKUAllowedOptionInfoProvider.GetSKUOptions().Where(sk => sk.SKUID == productSkuID).ToList();
            foreach (var item in allOptions)
            {
                if (!variantIDs.Any(i => i == item.OptionSKUID))
                {
                    SKUAllowedOptionInfoProvider.RemoveOptionFromProduct(productSkuID, item.OptionSKUID);
                }
            }

            foreach (var id in variantIDs)
            {
                if (!allOptions.Any(i => i.OptionSKUID == id))
                {
                    // Add to product if missing
                    SKUAllowedOptionInfoProvider.AddOptionToProduct(productSkuID, id);
                }
            }

            // Generate variants
            List<ProductVariant> variants = VariantHelper.GetAllPossibleVariants(productSkuID, categoryIDs);
            // Set variants
            foreach (var variant in variants)
            {
                if (variantIDs.Any(v => variant.ProductAttributes.Any(pr => pr.SKUID == v)))
                {
                    if (!VariantHelper.VariantExists(productSkuID, variant.ProductAttributes))
                    {
                        VariantHelper.SetProductVariant(variant);
                    }
                }
                else
                {
                    VariantHelper.DeleteVariant(variant);
                }
            }
        }
    }
}