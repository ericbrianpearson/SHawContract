using ShawContract.Application.Contracts.Services;
using ShawContract.Application.Models;
using ShawContract.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ShawContract.Controllers
{
    public class BaseController : Controller
    {
        protected IMasterPageService MasterPageService { get; }

        protected BaseController(IMasterPageService masterPageService)
        {
            this.MasterPageService = masterPageService;
        }

        public PageViewModel GetPageViewModel(string title)
        {
            return new PageViewModel()
            {
                Metadata = GetPageMetadata(title),
                HeaderMenuItems = this.MasterPageService.GetHeaderMenuItems() ?? new List<MenuItem>(),
                SecondaryMenuItems = this.MasterPageService.GetSecondaryMenuItems() ?? new List<MenuItem>(),
                FooterMenuItems = this.MasterPageService.GetFooterMenuItems() ?? new List<MenuItem>(),
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