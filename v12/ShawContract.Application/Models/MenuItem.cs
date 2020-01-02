using System.Collections.Generic;

namespace ShawContract.Application.Models
{
    public class MenuItem : BaseModel
    {
        public string DisplayName { get; set; }
        public bool IsClickable { get; set; }
        public string PageReference { get; set; }
        public bool OpenInNewTab { get; set; }
        public string CustomCSSClass { get; set; }
        public string DropDownCSSClass { get; set; }
        public string DropDownButtonLink { get; set; }
        public string DropDownButtonText { get; set; }

        public IEnumerable<MenuItem> SubItems { get; set; }

        public MenuItem()
        {
            this.SubItems = new List<MenuItem>();
        }
    }
}