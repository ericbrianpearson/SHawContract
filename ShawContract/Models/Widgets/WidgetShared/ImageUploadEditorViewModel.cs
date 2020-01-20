using ShawContract.Models.InlineEditors;
using ShawContract.Models.Widgets.FullWidthVideoWidget;

namespace ShawContract.Models.Widgets.WidgetShared
{
    public class ImageUploadEditorViewModel : InlineEditorViewModel
    {
        public bool HasImage { get; set; }

        public MediaLibraryViewModel MediaLibraryViewModel { get; set; }
    }
}