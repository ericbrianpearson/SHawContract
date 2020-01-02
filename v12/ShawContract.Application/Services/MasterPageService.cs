using System.Collections.Generic;
using ShawContract.Application.Contracts.Gateways;
using ShawContract.Application.Contracts.Infrastructure;
using ShawContract.Application.Contracts.Services;
using ShawContract.Application.Models;

namespace ShawContract.Application.Services
{
    public class MasterPageService : IMasterPageService
    {
        private ICultureInfoGateway CultureInfoGateway { get; }
        private IMenuGateway MenuGateway { get; }
        public ISiteContextService SiteContext { get; }

        public MasterPageService(ICultureInfoGateway cultureInfoGateway, IMenuGateway menuGateway, ISiteContextService siteContextService)
        {
            this.CultureInfoGateway = cultureInfoGateway;
            this.MenuGateway = menuGateway;
            this.SiteContext = siteContextService;
        }

        public IEnumerable<CultureInfo> GetSiteCultures()
        {
            return this.CultureInfoGateway.GetSiteCultures();
        }

        public IEnumerable<MenuItem> GetHeaderMenuItems()
        {
            return this.MenuGateway.GetHeaderMenuItems();
        }

        public IEnumerable<MenuItem> GetSecondaryMenuItems()
        {
            return this.MenuGateway.GetSecondaryMenuItems();
        }

        public IEnumerable<MenuItem> GetFooterMenuItems()
        {
            return this.MenuGateway.GetFooterMenuItems();
        }
    }
}