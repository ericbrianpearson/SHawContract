using Kentico.PageBuilder.Web.Mvc;
using Kentico.Forms.Web.Mvc;

namespace ShawContract.Models.Widgets.FeatureListWidget
{
    public class FeatureListWidgetProperties : IWidgetProperties
    {
        public string Title { get; set; }

        public string Subtitle { get; set; }

        [EditingComponent(CheckBoxComponent.IDENTIFIER, DefaultValue = false, Label = "Centered Text", Order = 0)]
        public bool IsTextCentered { get; set; }

        [EditingComponent(CheckBoxComponent.IDENTIFIER, DefaultValue = false, Label = "Show 'Learn more' Buttons", Order = 0)]
        public bool ShowButtons { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 1, Label = "Item Title 1")]
        public string SecondaryTitle1 { get; set; }

        [EditingComponent(TextAreaComponent.IDENTIFIER, Order = 2, Label = "Item Description 1")]
        public string Description1 { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 3, Label = "Item Image 1")]
        public string Image1 { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 4, Label = "Item Url 1")]
        public string LinkUrl1 { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 5, Label = "Item Title 2")]
        public string SecondaryTitle2 { get; set; }

        [EditingComponent(TextAreaComponent.IDENTIFIER, Order = 6, Label = "Item Description 2")]
        public string Description2 { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 7, Label = "Item Image 2")]
        public string Image2 { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 8, Label = "Item Url 2")]
        public string LinkUrl2 { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 9, Label = "Item Title 3")]
        public string SecondaryTitle3 { get; set; }

        [EditingComponent(TextAreaComponent.IDENTIFIER, Order = 10, Label = "Item Description 3")]
        public string Description3 { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 11, Label = "Item Image 3")]
        public string Image3 { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 12, Label = "Item Url 3")]
        public string LinkUrl3 { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 13, Label = "Item Title 4")]
        public string SecondaryTitle4 { get; set; }

        [EditingComponent(TextAreaComponent.IDENTIFIER, Order = 14, Label = "Item Description 4")]
        public string Description4 { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 15, Label = "Item Image 4")]
        public string Image4 { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 16, Label = "Item Url 4")]
        public string LinkUrl4 { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 17, Label = "Item Title 5")]
        public string SecondaryTitle5 { get; set; }

        [EditingComponent(TextAreaComponent.IDENTIFIER, Order = 18, Label = "Item Description 5")]
        public string Description5 { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 19, Label = "Item Image 5")]
        public string Image5 { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 20, Label = "Item Url 5")]
        public string LinkUrl5 { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 21, Label = "Item Title 6")]
        public string SecondaryTitle6 { get; set; }

        [EditingComponent(TextAreaComponent.IDENTIFIER, Order = 22, Label = "Item Description 6")]
        public string Description6 { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 23, Label = "Item Image 6")]
        public string Image6 { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 24, Label = "Item Url 6")]
        public string LinkUrl6 { get; set; }
    }
}