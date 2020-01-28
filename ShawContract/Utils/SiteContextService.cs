using CMS.SiteProvider;
using Kentico.Content.Web.Mvc;
using Kentico.Web.Mvc;
using ShawContract.Application.Contracts.Infrastructure;

namespace ShawContract.Utils
{
    public class SiteContextService : ISiteContextService
    {
        public string SiteName { get; }

        public string CurrentSiteCulture { get; }

        public string PreviewCulture => System.Web.HttpContext.Current.Kentico().Preview().CultureName;

        public bool IsPreviewEnabled => System.Web.HttpContext.Current.Kentico().Preview().Enabled;

        public int SiteContextID
        {
            get
            {
                return SiteContext.CurrentSiteID;
            }
            set
            {
                SiteContext.CurrentSiteID = value;
            }
        }

        public SiteContextService(string currentCulture, string siteName)
        {
            this.CurrentSiteCulture = currentCulture;
            this.SiteName = siteName;
        }
    }
}