using ShawContract.Application.Contracts.Services;
using ShawContract.Controllers.Widgets;
using ShawContract.Models.Widgets.FullWidthPhotoWidget;
using System;
using System.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using ShawContract.Models.Widgets.FullWidthVideoWidget;

[assembly: RegisterWidget(
    "ShawContract.Widget.FullWidthPhotoWidget",
    typeof(FullWidthPhotoWidgetController),
    "FullWidthPhotoWidget",
    Description = "FullWidthPhotoWidget",
    IconClass = "icon-picture")]

namespace ShawContract.Controllers.Widgets
{
    public class FullWidthPhotoWidgetController : WidgetController<FullWidthPhotoWidgetProperties>
    {
        public IMediaLibraryFileService MediaLibraryFileService { get; set; }
        public IMasterPageService MasterPageService { get; set; }

        public FullWidthPhotoWidgetController(IMediaLibraryFileService mediaLibraryFileService, IMasterPageService masterPageService)
        {
            MediaLibraryFileService = mediaLibraryFileService;
            MasterPageService = masterPageService;
        }

        // GET: FullWidthPhotoWidget
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

            return PartialView("Widgets/_FullWidthPhotoWidget", new FullWidthPhotoViewModel
            {
                Title = properties.Title,
                Description = properties.Description,
                PhotoCredit = properties.PhotoCredit,
                HasImage = hasImage,
                ImageUrl = imageUrl,
                ButtonText = properties.ButtonText,
                ButtonUrl = properties.ButtonUrl,
                TextBoxAlignment = properties.TextBoxAlignment,

                MediaLibraryViewModel = new MediaLibraryViewModel
                {
                    LibraryName = MediaLibraryFileService.MediaLibraryName,
                    LibrarySiteName = MediaLibraryFileService.MediaLibrarySiteName
                }
            });
        }
    }
}