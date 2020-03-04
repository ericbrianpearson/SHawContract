using AutoMapper;
using CMS.DocumentEngine;
using ShawContract.Application.Contracts.Gateways;
using ShawContract.Application.Contracts.Infrastructure;
using ShawContract.Application.Models;
using ShawContract.Providers.Kentico.PageHandler;
using System.Collections.Generic;
using System.Linq;

namespace ShawContract.Providers.Kentico
{
    public class MenuGateway : IMenuGateway
    {
        public MenuGateway(IPageContentHandler pageContentHandler, ILoggingService loggingService, IMapper mapper)
        {
            this.PageContentHandler = pageContentHandler;

            this.LoggingService = loggingService;
            this.Mapper = mapper;
        }

        private ILoggingService LoggingService { get; }

        private IMapper Mapper { get; }

        private IPageContentHandler PageContentHandler { get; }

        public IEnumerable<MenuItem> GetFooterMenuItems()
        {
            List<CMS.DocumentEngine.Types.ShawContract.MenuItem> kenticoMenuItems = this.PageContentHandler.GetPages<CMS.DocumentEngine.Types.ShawContract.MenuItem>()
                    .Path("/Menu/FooterMenu", PathTypeEnum.Children)
                    .AddColumns("DisplayName", "IsClickable", "PageReference", "OpenInNewTab", "NodeLevel")
                    .OrderByAscending("NodeOrder")
                    .Where(i => i.NodeLevel == 3)
                    .ToList();

            IEnumerable<MenuItem> menuItems = this.Mapper.Map<List<CMS.DocumentEngine.Types.ShawContract.MenuItem>, List<MenuItem>>(kenticoMenuItems);

            return menuItems;
        }

        public IEnumerable<MenuItem> GetHeaderMenuItems()
        {
            List<CMS.DocumentEngine.Types.ShawContract.MenuItem> kenticoMenuItems = this.PageContentHandler.GetPages<CMS.DocumentEngine.Types.ShawContract.MenuItem>()
                .Path("/Menu/HeaderMenu", PathTypeEnum.Children)
                .AddColumns("DisplayName", "IsClickable", "PageReference", "OpenInNewTab", "CustomCssClass", "DropDownButtonText", "DropDownButtonLink", "DropDownCSSClass", "NodeLevel")
                .OrderByAscending("NodeOrder")
                .Where(i => i.NodeLevel == 3)
                .ToList();

            IEnumerable<MenuItem> menuItems = this.Mapper.Map<List<CMS.DocumentEngine.Types.ShawContract.MenuItem>, List<MenuItem>>(kenticoMenuItems);

            for (int i = 0; i < kenticoMenuItems.Count(); i++)
            {
                GetSubMenuItems(kenticoMenuItems[i], menuItems.ToList()[i]);
            }

            return menuItems;
        }

        public IEnumerable<MenuItem> GetSecondaryMenuItems()
        {
            List<CMS.DocumentEngine.Types.ShawContract.MenuItem> kenticoMenuItems = this.PageContentHandler.GetPages<CMS.DocumentEngine.Types.ShawContract.MenuItem>()
                .Path("/Menu/SecondaryMenu", PathTypeEnum.Children)
                .AddColumns("DisplayName", "IsClickable", "PageReference", "OpenInNewTab", "NodeLevel")
                .OrderByAscending("NodeOrder")
                .Where(i => i.NodeLevel == 3)
                .ToList();

            IEnumerable<MenuItem> menuItems = this.Mapper.Map<List<CMS.DocumentEngine.Types.ShawContract.MenuItem>, List<MenuItem>>(kenticoMenuItems);

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
    }
}
