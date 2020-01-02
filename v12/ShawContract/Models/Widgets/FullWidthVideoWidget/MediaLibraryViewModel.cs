using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShawContract.Models.Widgets.FullWidthVideoWidget
{
    public class MediaLibraryViewModel
    {
        public string LibraryName { get; set; }
        public string LibrarySiteName { get; set; }

        public HashSet<string> AllowedImageExtensions => new HashSet<string>(new[]
           {
                ".gif",
                ".png",
                ".jpg",
                ".jpeg"
            }, StringComparer.OrdinalIgnoreCase); //todo: move to config service
    }
}