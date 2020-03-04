using ShawContract.Application.Models;
using System.Collections.Generic;

namespace ShawContract.Models.ContactUs
{
    public class ContactViewModel : IViewModel
    {
        public IEnumerable<ContactUsMenu> Menus { get; set; }
        public IEnumerable<ContactUsMenuItem> JobRole { get; set; }
        public IEnumerable<ContactUsMenuItem> AssistanceNeeded { get; set; }
        public ContactUsEmail Mail { get; set; }
    }
}