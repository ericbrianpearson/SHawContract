using ShawContract.Application.Contracts.Gateways;
using ShawContract.Application.Contracts.Infrastructure;
using ShawContract.Application.Contracts.Services;
using ShawContract.Application.Models;
using System.Collections.Generic;

namespace ShawContract.Application.Services
{
    public class MasterPageService : IMasterPageService
    {
        private const string FooterMenuItemsCachingKey = "FooterMenuItemsCachingKey";
        private const string HeaderMenuItemsCachingKey = "HeaderMenuItemsCachingKey";
        private const string SecondaryMenuItemsCachingKey = "SecondaryMenuItemsCachingKey";

        public MasterPageService(ICultureInfoGateway cultureInfoGateway, IMenuGateway menuGateway, ISiteContextService siteContextService, ICachingService cachingService)
        {
            this.CultureInfoGateway = cultureInfoGateway;
            this.MenuGateway = menuGateway;
            this.CachingService = cachingService;
            this.SiteContext = siteContextService;
        }

        public ISiteContextService SiteContext { get; }

        private ICachingService CachingService { get; }

        private ICultureInfoGateway CultureInfoGateway { get; }

        private IMenuGateway MenuGateway { get; }

        public IEnumerable<MenuItem> GetFooterMenuItems()
        {
            return CachingService.GetOrCreateItem<IEnumerable<MenuItem>>(FooterMenuItemsCachingKey, () =>
            {
                return this.MenuGateway.GetFooterMenuItems();
            });
        }

        public IEnumerable<MenuItem> GetHeaderMenuItems()
        {
            return CachingService.GetOrCreateItem<IEnumerable<MenuItem>>(HeaderMenuItemsCachingKey, () =>
            {
                return this.MenuGateway.GetHeaderMenuItems();
            });
        }

        public IEnumerable<MenuItem> GetSecondaryMenuItems()
        {
            return CachingService.GetOrCreateItem<IEnumerable<MenuItem>>(SecondaryMenuItemsCachingKey, () =>
            {
                return this.MenuGateway.GetSecondaryMenuItems();
            });
        }

        public IEnumerable<CultureInfo> GetSiteCultures()
        {
            return this.CultureInfoGateway.GetSiteCultures();
        }
    }
}
