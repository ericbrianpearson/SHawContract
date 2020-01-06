using System.Collections.Generic;
using ShawContract.Application.Contracts.Infrastructure;
using ShawContract.Application.Models;

namespace ShawContract.Application.Contracts.Services
{
    public interface IMasterPageService
    {
        IEnumerable<CultureInfo> GetSiteCultures();

        IEnumerable<MenuItem> GetHeaderMenuItems();

        IEnumerable<MenuItem> GetSecondaryMenuItems();

        IEnumerable<MenuItem> GetFooterMenuItems();

        ISiteContextService SiteContext { get; }
    }
}