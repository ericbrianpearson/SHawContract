using ShawContract.Application.Models;
using System.Collections.Generic;

namespace ShawContract.Application.Contracts.Services
{
    public interface IContactUsService
    {
        IEnumerable<ContactUsMenu> GetDropDowns(string nodeAlias);
    }
}
