using System.Collections.Generic;
using System.Web.Mvc;
using CMS.Helpers;
using ShawContract.Application.Contracts.Services;
using ShawContract.Application.Models;
using ShawContract.Models;

namespace ShawContract.Controllers
{
    public class BaseController : Controller
    {
        protected BaseController(IMasterPageService masterPageService)
        {
            this.MasterPageService = masterPageService;
        }

        protected IMasterPageService MasterPageService { get; }

        public PageViewModel GetPageViewModel(string title)
        {
            IEnumerable<MenuItem> headerItems = CacheHelper.Cache(() => this.MasterPageService.GetHeaderMenuItems(), new CacheSettings(10, "ShawContract_HeaderMenuItems"));
            IEnumerable<MenuItem> secondaryItems = CacheHelper.Cache(() => this.MasterPageService.GetSecondaryMenuItems(), new CacheSettings(10, "ShawContract_SecondaryMenuItems"));
            IEnumerable<MenuItem> footerItems = CacheHelper.Cache(() => this.MasterPageService.GetFooterMenuItems(), new CacheSettings(10, "ShawContract_FooterMenuItems"));

            return new PageViewModel()
            {
                Metadata = GetPageMetadata(title),
                HeaderMenuItems = headerItems,
                SecondaryMenuItems = secondaryItems,
                FooterMenuItems = footerItems,
                Cultures = this.MasterPageService.GetSiteCultures()
            };
        }

        public PageViewModel<TViewModel> GetPageViewModel<TViewModel>(TViewModel data, string title) where TViewModel : IViewModel
        {
            return new PageViewModel<TViewModel>()
            {
                Metadata = GetPageMetadata(title),
                HeaderMenuItems = this.MasterPageService.GetHeaderMenuItems() ?? new List<MenuItem>(),
                SecondaryMenuItems = this.MasterPageService.GetSecondaryMenuItems() ?? new List<MenuItem>(),
                FooterMenuItems = this.MasterPageService.GetFooterMenuItems() ?? new List<MenuItem>(),
                Cultures = this.MasterPageService.GetSiteCultures(),
                Data = data
            };
        }

        private PageMetadata GetPageMetadata(string title)
        {
            return new PageMetadata()
            {
                Title = title,
                CompanyName = MasterPageService.SiteContext.SiteName
            };
        }
    }
}
