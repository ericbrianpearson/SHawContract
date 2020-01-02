using System.Collections.Generic;
using ShawContract.Application.Models;

namespace ShawContract.Application.Contracts.Gateways
{
    public interface ICultureInfoGateway
    {
        IEnumerable<CultureInfo> GetSiteCultures();
    }
}