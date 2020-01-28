using CMS.SiteProvider;
using ShawContract.Application.Contracts.Gateways;
using ShawContract.Application.Contracts.Infrastructure;
using ShawContract.Application.Models;
using System.Collections.Generic;
using System.Linq;

namespace ShawContract.Providers.Kentico
{
    public class CultureInfoGateway : ICultureInfoGateway
    {
        private ISiteContextService SiteContext { get; }

        public CultureInfoGateway(ISiteContextService siteContext)
        {
            SiteContext = siteContext;
        }

        public IEnumerable<CultureInfo> GetSiteCultures() =>
            CultureSiteInfoProvider.GetSiteCultures(this.SiteContext.SiteName)
                .Items
                .Select(culture =>
                    new CultureInfo()
                    {
                        //TODO: remove if not needed
                        // CultureGuid = culture.CultureGUID,
                        CultureCode = culture.CultureCode,
                        CultureName = culture.CultureName,
                        CultureShortName = culture.CultureShortName
                    }
            );
    }
}