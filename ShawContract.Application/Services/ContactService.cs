using ShawContract.Application.Contracts.Gateways;
using ShawContract.Application.Contracts.Services;
using ShawContract.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShawContract.Application.Services
{
    public class ContactService : IContactService
    {
        private IContactGateway ContactGateway { get; }
        public ContactService(IContactGateway contactGateway)
        {
            this.ContactGateway = contactGateway;
        }
        public ContactPage GetContactPage(string nodeAlias)
        {
            return ContactGateway.GetContactPage(nodeAlias);
        }
    }
}
