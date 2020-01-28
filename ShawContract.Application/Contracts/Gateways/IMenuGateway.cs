using System.Collections.Generic;
using ShawContract.Application.Models;

namespace ShawContract.Application.Contracts.Gateways
{
    public interface IMenuGateway
    {
        IEnumerable<MenuItem> GetHeaderMenuItems();

        IEnumerable<MenuItem> GetSecondaryMenuItems();

        IEnumerable<MenuItem> GetFooterMenuItems();
    }
}