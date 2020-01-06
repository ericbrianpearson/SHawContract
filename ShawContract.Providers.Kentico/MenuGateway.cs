using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CMS.DocumentEngine;
using ShawContract.Application.Contracts.Gateways;
using ShawContract.Application.Contracts.Infrastructure;
using ShawContract.Application.Models;
using ShawContract.Providers.Kentico.PageHandler;

namespace ShawContract.Providers.Kentico
{
    public class MenuGateway : IMenuGateway
    {
        private IMapper Mapper { get; }
        private IPageContentHandler PageContentHandler { get; }
        private ICachingService CachingService { get; }
        private ILoggingService LoggingService { get; }

        private const string HeaderMenuItemsCachingKey = "HeaderMenuItemsCachingKey";
        private const string SecondaryMenuItemsCachingKey = "SecondaryMenuItemsCachingKey";
        private const string FooterMenuItemsCachingKey = "FooterMenuItemsCachingKey";

        public MenuGateway(IPageContentHandler pageContentHandler, ICachingService cachingService, ILoggingService loggingService, IMapper mapper)
        {
            this.PageContentHandler = pageContentHandler;
            this.CachingService = cachingService;
            this.LoggingService = loggingService;
            this.Mapper = mapper;
        }

        public IEnumerable<MenuItem> GetHeaderMenuItems()
        {
            IEnumerable<MenuItem> menuItems = CachingService.GetItem<IEnumerable<MenuItem>>(HeaderMenuItemsCachingKey);
            if (menuItems == null)
            {
                LoggingService.Log(LogLevel.Debug, "Header Menu Items not found in Cache", string.Empty);

                List<CMS.DocumentEngine.Types.ShawContract.MenuItem> kenticoMenuItems = this.PageContentHandler.GetPages<CMS.DocumentEngine.Types.ShawContract.MenuItem>()
                        .Path("/Menu/HeaderMenu", PathTypeEnum.Children)
                        .AddColumns("DisplayName", "IsClickable", "PageReference", "OpenInNewTab", "CustomCssClass", "DropDownButtonText", "DropDownButtonLink", "DropDownCSSClass", "NodeLevel")
                        .OrderByAscending("NodeOrder")
                        .Where(i => i.NodeLevel == 3)
                        .ToList();

                menuItems = this.Mapper.Map<List<CMS.DocumentEngine.Types.ShawContract.MenuItem>, List<MenuItem>>(kenticoMenuItems);

                for (int i = 0; i < kenticoMenuItems.Count(); i++)
                {
                    GetSubMenuItems(kenticoMenuItems[i], menuItems.ToList()[i]);
                }

                CachingService.SetItem(HeaderMenuItemsCachingKey, menuItems, null);

                LoggingService.Log(LogLevel.Debug, "Header Menu Items added to Cache", menuItems);
            }
            return menuItems;
        }

        private void GetSubMenuItems(CMS.DocumentEngine.Types.ShawContract.MenuItem kenticoMenuItem, MenuItem menuItem)
        {
            if (kenticoMenuItem.Children.Count > 0)
            {
                List<CMS.DocumentEngine.Types.ShawContract.MenuItem> subItems = this.PageContentHandler.GetPages<CMS.DocumentEngine.Types.ShawContract.MenuItem>()
                    .AddColumns("DisplayName", "IsClickable", "PageReference", "OpenInNewTab", "NodeParentID", "NodeLevel")
                    .OrderByAscending("NodeOrder")
                    .Where(s => s.NodeLevel == kenticoMenuItem.NodeLevel + 1 && s.NodeParentID == kenticoMenuItem.NodeID)
                    .ToList();

                menuItem.SubItems = this.Mapper.Map<List<CMS.DocumentEngine.Types.ShawContract.MenuItem>, List<MenuItem>>(subItems);

                for (int i = 0; i < subItems.Count; i++)
                {
                    GetSubMenuItems(subItems[i], menuItem.SubItems.ToList()[i]);
                }
            }
        }

        public IEnumerable<MenuItem> GetSecondaryMenuItems()
        {
            IEnumerable<MenuItem> menuItems = CachingService.GetItem<IEnumerable<MenuItem>>(SecondaryMenuItemsCachingKey);
            if (menuItems == null)
            {
                LoggingService.Log(LogLevel.Debug, "Secondary Menu Items not found in Cache", string.Empty);

                //TODO : Need to add caching check here
                List<CMS.DocumentEngine.Types.ShawContract.MenuItem> kenticoMenuItems = this.PageContentHandler.GetPages<CMS.DocumentEngine.Types.ShawContract.MenuItem>()
                        .Path("/Menu/SecondaryMenu", PathTypeEnum.Children)
                        .AddColumns("DisplayName", "IsClickable", "PageReference", "OpenInNewTab", "NodeLevel")
                        .OrderByAscending("NodeOrder")
                        .Where(i => i.NodeLevel == 3)
                        .ToList();

                menuItems = this.Mapper.Map<List<CMS.DocumentEngine.Types.ShawContract.MenuItem>, List<MenuItem>>(kenticoMenuItems);

                CachingService.SetItem(SecondaryMenuItemsCachingKey, menuItems, null);

                LoggingService.Log(LogLevel.Debug, "Secondary Menu Items added to Cache", menuItems);
            }
            return menuItems;
        }

        public IEnumerable<MenuItem> GetFooterMenuItems()
        {
            IEnumerable<MenuItem> menuItems = CachingService.GetItem<IEnumerable<MenuItem>>(FooterMenuItemsCachingKey);
            if (menuItems == null)
            {
                LoggingService.Log(LogLevel.Debug, "Footer Menu Items not found in Cache", string.Empty);

                List<CMS.DocumentEngine.Types.ShawContract.MenuItem> kenticoMenuItems = this.PageContentHandler.GetPages<CMS.DocumentEngine.Types.ShawContract.MenuItem>()
                        .Path("/Menu/FooterMenu", PathTypeEnum.Children)
                        .AddColumns("DisplayName", "IsClickable", "PageReference", "OpenInNewTab", "NodeLevel")
                        .OrderByAscending("NodeOrder")
                        .Where(i => i.NodeLevel == 3)
                        .ToList();

                menuItems = this.Mapper.Map<List<CMS.DocumentEngine.Types.ShawContract.MenuItem>, List<MenuItem>>(kenticoMenuItems);

                CachingService.SetItem(FooterMenuItemsCachingKey, menuItems, null);

                LoggingService.Log(LogLevel.Debug, "Footer Menu Items added to Cache", menuItems);
            }
            return menuItems;
        }
    }
}