using Kentico.PageBuilder.Web.Mvc;
using Kentico.Forms.Web.Mvc;

namespace ShawContract.Models.Widgets.FeatureListWidget
{
    public class FeatureListWidgetProperties : IWidgetProperties
    {
        public string Title { get; set; }

        public string Subtitle { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 0, Label = "List one icon")]
        public string Icon1 { get; set; }
        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 0, Label = "List one secondary title")]
        public string SecondaryTitle1 { get; set; }
        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 0, Label = "List one link Url")]
        public string LinkUrl1 { get; set; }
        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 0, Label = "List one description")]
        public string Description1 { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 1, Label = "List two icon")]
        public string Icon2 { get; set; }
        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 1, Label = "List two secondary title")]
        public string SecondaryTitle2 { get; set; }                               
        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 1, Label = "List two link Url")]
        public string LinkUrl2 { get; set; }                                      
        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 1, Label = "List two description")]
        public string Description2 { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 2, Label = "List three icon")]
        public string Icon3 { get; set; }
        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 2, Label = "List three secondary title")]
        public string SecondaryTitle3 { get; set; }                               
        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 2, Label = "List three link Url")]
        public string LinkUrl3 { get; set; }                                      
        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 2, Label = "List three description")]
        public string Description3 { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 3, Label = "List four icon")]
        public string Icon4 { get; set; }
        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 3, Label = "List four secondary title")]
        public string SecondaryTitle4 { get; set; }                               
        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 3, Label = "List four link Url")]
        public string LinkUrl4 { get; set; }                                      
        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 3, Label = "List four description")]
        public string Description4 { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 4, Label = "List five icon")]
        public string Icon5 { get; set; }
        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 4, Label = "List five secondary title")]
        public string SecondaryTitle5 { get; set; }                               
        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 4, Label = "List five link Url")]
        public string LinkUrl5 { get; set; }                                      
        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 4, Label = "List five description")]
        public string Description5 { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 5, Label = "List six icon")]
        public string Icon6 { get; set; }
        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 5, Label = "List six secondary title")]
        public string SecondaryTitle6 { get; set; }                               
        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 5, Label = "List six link Url")]
        public string LinkUrl6 { get; set; }                                      
        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 5, Label = "List six description")]
        public string Description6 { get; set; }
    }
}