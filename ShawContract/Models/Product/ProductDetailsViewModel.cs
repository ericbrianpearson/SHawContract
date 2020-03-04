using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using Kentico.Membership;
using ShawContract.Application.Models;
using ShawContract.Application.Models.Product;
using ShawContract.Application.Models.Product.Common;
using ShawContract.Models.Personalization;
namespace ShawContract.Models.Product
{
    public class ProductDetailsViewModel : IViewModel
    {
        public string UserId { get; set; }
        public BaseSpecification Product { get; set; }
        public string ProductSize { get; set; }

        //Images
        public Dictionary<string, int> InstallationParametersMapping  => TrycicleInstallsParameters.ParametersMapping;
        public int SelectedInstallParameter { get; set; }

        public Color SelectedColor { get; set; }

        public string SizeForImage { get; set; }

        public string SelectedRoomScene { get; set; }

        public string SingleTileImageUrl { get; set; }      

        public string RoomSceneUrl { get; set; }

        public string InstallImageUrl { get; set; }


        //Carpet and Rug
        public string Backing { get; set; }

        public string Fiber { get; set; }
        public MeasuringSystem TuftedWeight { get; set; }

        //Hardwood and Resilient
        public IEnumerable<string> Species { get; set; }

        public string EdgeProfile { get; set; }
        public string Finish { get; set; }
        public MeasuringSystem OverallThickness { get; set; }
        public string Installation { get; set; }

        public List<CollectionProduct> CollectionProducts { get; set; }

        public List<CollectionProduct> SimilarProducts { get; set; }

        public List<ProductBoard> ProductBoards { get; set; }

        public ProductDetailsViewModel(string userId, BaseSpecification product, IEnumerable<CollectionProduct> collectionProducts,
            IEnumerable<CollectionProduct> similarProducts, IEnumerable<ProductBoard> productBoards, string colorNumber)
        {

            this.Product = product;
            this.ProductBoards = productBoards.ToList();
            this.CollectionProducts = collectionProducts.ToList();
            this.SimilarProducts = similarProducts.ToList();
            
            this.SelectedColor = product.Colors.FirstOrDefault(p=>p.ColorNumber == colorNumber) ?? product.Colors.FirstOrDefault();
            this.ProductSize = GetProductSize();
            this.SizeForImage = "9x36";
            SetPorperties();
            SetColorImages();
        }
        private void SetColorImages()
        {
            if (this.Product.Colors != null && this.Product.Colors.Count() > 0)
            {
                this.SelectedInstallParameter = 1;
                var colors = this.Product.Colors.ToList();
                this.SelectedRoomScene = this.Product.KontentData.AvailableRoomScenes.FirstOrDefault().Id;
                if (this.Product.KontentData.AvailableRoomScenes != null && this.Product.KontentData.AvailableRoomScenes.Count() > 0)
                {
                    this.SelectedInstallParameter = this.Product.ProductType.ToLower().Trim() == "broadloom" ? 1 : GetInstallParameter();
                    this.RoomSceneUrl = string.Format(@"http://scrl.img.trykcloudstatic.com/designs/{0}/colors/{1}/rooms/{2}/installs/{3}?pixels=500",
                        this.Product.StyleNumber, this.SelectedColor.ColorNumber, this.SelectedRoomScene, this.SelectedInstallParameter);
                }

                foreach (var color in colors)
                {
                    //TODO: generate the link based on product type
                    color.ImageUrl = string.Format("http://scrl.img.trykcloudstatic.com/designs/{0}/colors/{1}/installs/1?physWidth=0.5ft&physHeight=0.5ft&pixels=200", this.Product.StyleNumber, color.ColorNumber);                   
                }

                this.SingleTileImageUrl = string.Format(@"http://scrl.img.trykcloudstatic.com/designs/{0}/colors/{1}/tiles/{2}/1?pixels=500", this.Product.StyleNumber, this.SelectedColor.ColorNumber, this.SizeForImage);
                this.InstallImageUrl = string.Format(@"http://scrl.img.trykcloudstatic.com/designs/{0}/colors/{1}/installs/{2}?physWidth=9ft&physHeight=6ft&pixels=500", this.Product.StyleNumber, this.SelectedColor.ColorNumber, this.SelectedInstallParameter);
            }
        }

        private int GetInstallParameter()
        {
            if (this.Product.ProductSize != null && this.Product.ProductSize.Length != null && this.Product.ProductSize.Width != null
                && this.Product.RecommendedInstallationMethods != null && this.Product.RecommendedInstallationMethods.Count() > 0)
            {
                var installationMethod = Regex.Replace(this.Product.RecommendedInstallationMethods.FirstOrDefault(), @"\s+", String.Empty).ToLower();
                 this.SizeForImage = (int)this.Product.ProductSize.Width.Imperial.FormattedValue + "x" + (int)this.Product.ProductSize.Length.Imperial.FormattedValue;
                installationMethod += this.SizeForImage;
                return TrycicleInstallsParameters.ParametersMapping[installationMethod];
            }
            return 1;
        }

        private void SetPorperties()
        {
            switch (this.Product.InventoryType)
            {
                case "Carpet":
                case "Rug":
                    this.Backing = (this.Product as CarpetSpecification).Backing;
                    this.Fiber = (this.Product as CarpetSpecification).Fiber;
                    this.TuftedWeight = (this.Product as CarpetSpecification).TuftedWeight;
                    break;

                case "Resilient":
                    this.Finish = (this.Product as ResilientSpecification).Finish;
                    this.OverallThickness = (this.Product as ResilientSpecification).OverallThickness;
                    this.Installation = (this.Product as ResilientSpecification).Installation;
                    break;

                case "Hardwood":
                    this.Finish = (this.Product as HardwoodSpecification).Finish;
                    this.OverallThickness = (this.Product as HardwoodSpecification).OverallThickness;
                    this.Installation = (this.Product as HardwoodSpecification).Installation;
                    this.EdgeProfile = (this.Product as HardwoodSpecification).EdgeProfile;
                    this.Species = (this.Product as HardwoodSpecification).Species;
                    break;

                default:
                    break;
            }
        }

        private string GetProductSize()
        {
            string imperialSize = "";
            string metricSize = "";
            if (this.Product.ProductSize != null)
            {
                if (!string.IsNullOrEmpty(this.Product.ProductSize.ImperialDisplayValue))
                {
                    imperialSize = this.Product.ProductSize.ImperialDisplayValue;
                }
                else if (this.Product.ProductSize.Width != null)
                {
                    imperialSize = this.Product.ProductSize.Width.Imperial.DisplayValue;

                    if (this.Product.ProductSize.Length != null)
                    {
                        imperialSize += " x " + this.Product.ProductSize.Length.Imperial.DisplayValue;
                    }
                }

                if (!string.IsNullOrEmpty(this.Product.ProductSize.MetricDisplayValue))
                {
                    metricSize = this.Product.ProductSize.MetricDisplayValue;
                }
                else if (this.Product.ProductSize.Width != null)
                {
                    metricSize = this.Product.ProductSize.Width.Metric.DisplayValue;

                    if (this.Product.ProductSize.Length != null)
                    {
                        metricSize += " x " + this.Product.ProductSize.Length.Metric.DisplayValue;
                    }
                }
            }

            if (!string.IsNullOrEmpty(imperialSize) && !string.IsNullOrEmpty(metricSize))
            {
                return imperialSize + " | " + metricSize;
            }
            return imperialSize ?? metricSize;
        }
    }
}