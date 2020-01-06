using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;

namespace ShawContract.Models.Widgets.ButtonCollectionWidget
{
    public class ButtonCollectionWidgetProperties : IWidgetProperties
    {
        public string Title { get; set; }
        public string Text { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 0, Label = "Button 1 text")]
        public string Button1Text { get; set; }
        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 0, Label = "Button 1 url")]
        public string Button1Url { get; set; }


        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 0, Label = "Button 2 text")]
        public string Button2Text { get; set; }
        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 0, Label = "Button 2 url")]
        public string Button2Url { get; set; }


        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 0, Label = "Button 3 text")]
        public string Button3Text { get; set; }
        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 0, Label = "Button 3 url")]
        public string Button3Url { get; set; }


        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 0, Label = "Button 4 text")]
        public string Button4Text { get; set; }
        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 0, Label = "Button 4 url")]
        public string Button4Url { get; set; }
    }
}