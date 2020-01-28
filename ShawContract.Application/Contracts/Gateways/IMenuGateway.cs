using ShawContract.Application.Models;
using System.Collections.Generic;

namespace ShawContract.Application.Contracts.Gateways
{
    public interface IMenuGateway
    {
        IEnumerable<MenuItem> GetHeaderMenuItems();

        IEnumerable<MenuItem> GetSecondaryMenuItems();

        IEnumerable<MenuItem> GetFooterMenuItems();
    }
}