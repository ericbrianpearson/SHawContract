using System.Collections.Generic;

namespace ShawContract.Application.Models
{
    public class ContactUsMenu
    {
        public string Title { get; set; }
        public string PathAlias { get; set; }
        public int MenuType { get; set; }
        public IEnumerable<ContactUsMenuItem> Items { get; set; }
    }
}
