using Kentico.PageBuilder.Web.Mvc;
using ShawContract.Application.Contracts.Services;
using ShawContract.Controllers.Widgets;
using ShawContract.Models.Widgets.FullWidthVideoWidget;
using System;
using System.Text.RegularExpressions;
using System.Web.Mvc;

[assembly: RegisterWidget(
    "ShawContract.Widget.FullWidthVideoWidget",
    typeof(FullWidthVideoWidgetController),
    "Full Width Video ",
    Description = "Full Width Video ",
    IconClass = "icon-pictures")]

namespace ShawContract.Controllers.Widgets
{
    public class FullWidthVideoWidgetController : WidgetController<FullWidthVideoWidgetProperties>
    {
        public IMediaLibraryFileService MediaLibraryFileService { get; set; }
        public IMasterPageService MasterPageService { get; set; }

        public FullWidthVideoWidgetController(IMediaLibraryFileService mediaLibraryFileService, IMasterPageService masterPageService)
        {
            MediaLibraryFileService = mediaLibraryFileService;
            MasterPageService = masterPageService;
        }

        // GET: FullWidthVideoWidget
        public ActionResult Index()
        {
            var properties = GetProperties();
            bool hasImage = false;
            string imageUrl = null;

            return PartialView("Widgets/_FullWidthVideoWidget", new FullWidthVideoWidgetViewModel
            {
                HasImage = hasImage,
                Title = properties.Title,
                Description = properties.Description,
                VideoUrl = Regex.Replace(properties.VideoUrl ?? "", "<.*?>", string.Empty),
                ImageUrl = properties.ImageUrl,
                PhotoCredit = properties.PhotoCredit,
                MediaLibraryViewModel = new MediaLibraryViewModel
                {
                    LibraryName = MediaLibraryFileService.MediaLibraryName,
                    LibrarySiteName = MediaLibraryFileService.MediaLibrarySiteName
                }
            });
        }
    }
}