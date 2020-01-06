using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;

namespace ShawContract.Models.Widgets.BulletListWidget
{
    public class BulletListWidgetProperties : IWidgetProperties
    {
        public string Title { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 0, Label = "Image Url")]
        public string MainImage { get; set; }

        public string PhotoCredit { get; set; }

        [EditingComponent(DropDownComponent.IDENTIFIER, Label = "Alignment", Order = 0)]
        [EditingComponentProperty(nameof(DropDownProperties.DataSource), "right; Image Right\r\nleft; Image Left")]
        public string ImageAlignment { get; set; } = "right";

        public string Text { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 0, Label = "Item Link Url 1")]
        public string Url { get; set; }

        public string Text1 { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 0, Label = "Item Link Url 2")]
        public string Url1 { get; set; }

        public string Text2 { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 0, Label = "Item Link Url 3")]
        public string Url2 { get; set; }

        public string Text3 { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 0, Label = "Item Link Url 4")]
        public string Url3 { get; set; }

        public string Text4 { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 0, Label = "Item Link Url 5")]
        public string Url4 { get; set; }

        public string Text5 { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 0, Label = "Item Link Url 6")]
        public string Url5 { get; set; }

        public string Text6 { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 0, Label = "Item Link Url 7")]
        public string Url6 { get; set; }

        public string Text7 { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 0, Label = "Item Link Url 8")]
        public string Url7 { get; set; }

        public string Text8 { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 0, Label = "Item Link Url 9")]
        public string Url8 { get; set; }

        public string Text9 { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 0, Label = "Item Link Url 10")]
        public string Url9 { get; set; }
    }
}