using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShawContract.Application.Contracts.Infrastructure;
using ShawContract.Application.Contracts.Services;

namespace ShawContract.Controllers.InlineEditors
{
    public class ImageUploadController : BaseController
    {
        public ILoggingService LoggingService { get; set; }

        public IMediaLibraryFileService MediaLibraryService { get; set; }

        public ImageUploadController(IMasterPageService masterPageService,
            IMediaLibraryFileService mediaLibraryFileService,
            ILoggingService loggingService) : base(masterPageService)
        {
            MediaLibraryService = mediaLibraryFileService;
            LoggingService = loggingService;
        }

        [HttpPost]
        public ActionResult Upload(string mediaLibraryName, string mediaLibrarySiteName)
        {
            var imageGuid = Guid.Empty;

            if (Request.Files[0] is HttpPostedFileWrapper file)
            {
                try
                {
                    imageGuid = MediaLibraryService.AddMediaLibraryFile(file, mediaLibraryName, mediaLibrarySiteName);
                }
                catch (Exception ex)
                {
                    LoggingService.Log(LogLevel.Error, "Uploading image exception", string.Empty, ex);
                }

                return Json(new { guid = imageGuid });
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
    }
}