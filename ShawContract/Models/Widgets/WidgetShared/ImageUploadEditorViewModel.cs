using ShawContract.Models.InlineEditors;
using ShawContract.Models.Widgets.FullWidthVideoWidget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShawContract.Models.Widgets.WidgetShared
{
    public class ImageUploadEditorViewModel : InlineEditorViewModel
    {
        public bool HasImage { get; set; }

        public MediaLibraryViewModel MediaLibraryViewModel { get; set; }
    }
}