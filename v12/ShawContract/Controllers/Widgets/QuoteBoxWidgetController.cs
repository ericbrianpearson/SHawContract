using Kentico.PageBuilder.Web.Mvc;
using ShawContract.Application.Contracts.Services;
using ShawContract.Controllers.Widgets;
using ShawContract.Models.Widgets.FullWidthVideoWidget;
using ShawContract.Models.Widgets.QuoteBoxWidget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

[assembly: RegisterWidget(
    "ShawContract.Widget.QuoteBoxWidget",
    typeof(QuoteBoxWidgetController),
    "QuoteBoxWidget",
    Description = "QuoteBoxWidget",
    IconClass = "icon-newspaper")]

namespace ShawContract.Controllers.Widgets
{
    public class QuoteBoxWidgetController : WidgetController<QuoteBoxWidgetProperties>
    {
        //todo: create a base controller
        public IMediaLibraryFileService MediaLibraryFileService { get; set; }

        public IMasterPageService MasterPageService { get; set; }

        public QuoteBoxWidgetController(IMediaLibraryFileService mediaLibraryFileService, IMasterPageService masterPageService)
        {
            MediaLibraryFileService = mediaLibraryFileService;
            MasterPageService = masterPageService;
        }

        // GET: QuoteBoxWidget
        public ActionResult Index()
        {
            var properties = GetProperties();
            bool hasImage = false;
            string imageUrl = null;

            if (properties.ImageGuid != Guid.Empty)
            {
                hasImage = true;
                imageUrl = MediaLibraryFileService.GetMediaLibrary(properties.ImageGuid).DirectUrl;
            }

            return PartialView("Widgets/_QuoteBoxWidget", new QuoteBoxWidgetViewModel
            {
                Quote = properties.Quote,
                Attribution = properties.Attribution,
                PhotoCredit = properties.PhotoCredit,
                HasImage = hasImage,
                ImageUrl = imageUrl,
                ButtonText = properties.ButtonText,
                ButtonUrl = properties.ButtonUrl,
                ImageAlignment = properties.ImageAlignment,

                MediaLibraryViewModel = new MediaLibraryViewModel
                {
                    LibraryName = MediaLibraryFileService.MediaLibraryName,
                    LibrarySiteName = MediaLibraryFileService.MediaLibrarySiteName
                }
            });
        }
    }
}