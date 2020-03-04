using ShawContract.Application.Contracts.Gateways;
using ShawContract.Application.Contracts.Services;
using ShawContract.Application.Models;
using System.Collections.Generic;

namespace ShawContract.Application.Services
{
    public class ContactUsService : IContactUsService
    {
        private IContactUsGateway DropDownGateway { get; }

        public ContactUsService(IContactUsGateway dropDownGateway)
        {
            this.DropDownGateway = dropDownGateway;
        }

        public IEnumerable<ContactUsMenu> GetDropDowns(string nodeAlias)
        {
            var menus = DropDownGateway.GetDropDowns(nodeAlias);
            return menus;
        }
    }
}
