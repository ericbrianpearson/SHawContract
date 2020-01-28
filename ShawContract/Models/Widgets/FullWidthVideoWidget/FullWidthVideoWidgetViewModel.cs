namespace ShawContract.Models.Widgets.FullWidthVideoWidget
{
    public class FullWidthVideoWidgetViewModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string PhotoCredit { get; set; }
        public string VideoUrl { get; set; }

        public bool HasImage { get; set; }

        public string ImageUrl { get; set; }

        public MediaLibraryViewModel MediaLibraryViewModel { get; set; }
    }
}