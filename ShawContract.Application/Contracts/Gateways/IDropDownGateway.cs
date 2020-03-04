using ShawContract.Application.Models;
using System.Collections.Generic;

namespace ShawContract.Application.Contracts.Gateways
{
    public interface IContactUsGateway
    {
        IEnumerable<ContactUsMenu> GetDropDowns(string nodeAlias);
    }
}
