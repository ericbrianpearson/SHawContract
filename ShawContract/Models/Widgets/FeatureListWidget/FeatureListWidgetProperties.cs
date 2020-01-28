using Kentico.PageBuilder.Web.Mvc;
using Kentico.Forms.Web.Mvc;

namespace ShawContract.Models.Widgets.FeatureListWidget
{
    public class FeatureListWidgetProperties : IWidgetProperties
    {
        public string Title { get; set; }

        public string Subtitle { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 0, Label = "Item Title 1")]
        public string SecondaryTitle1 { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 1, Label = "Item Description 1")]
        public string Description1 { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 2, Label = "Item Icon 1")]
        public string Icon1 { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 3, Label = "Item Url 1")]
        public string LinkUrl1 { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 4, Label = "Item Title 2")]
        public string SecondaryTitle2 { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 5, Label = "Item Description 2")]
        public string Description2 { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 6, Label = "Item Icon 2")]
        public string Icon2 { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 7, Label = "Item Url 2")]
        public string LinkUrl2 { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 8, Label = "Item Title 3")]
        public string SecondaryTitle3 { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 9, Label = "Item Description 3")]
        public string Description3 { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 10, Label = "Item Icon 3")]
        public string Icon3 { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 11, Label = "Item Url 3")]
        public string LinkUrl3 { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 12, Label = "Item Title 4")]
        public string SecondaryTitle4 { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 13, Label = "Item Description 4")]
        public string Description4 { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 14, Label = "Item Icon 4")]
        public string Icon4 { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 15, Label = "Item Url 4")]
        public string LinkUrl4 { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 16, Label = "Item Title 5")]
        public string SecondaryTitle5 { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 17, Label = "Item Description 5")]
        public string Description5 { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 18, Label = "Item Icon 5")]
        public string Icon5 { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 19, Label = "Item Url 5")]
        public string LinkUrl5 { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 20, Label = "Item Title 6")]
        public string SecondaryTitle6 { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 21, Label = "Item Description 6")]
        public string Description6 { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 22, Label = "Item Icon 6")]
        public string Icon6 { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 23, Label = "Item Url 6")]
        public string LinkUrl6 { get; set; }
    }
}