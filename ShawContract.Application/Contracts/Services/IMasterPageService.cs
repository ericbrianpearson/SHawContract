using ShawContract.Application.Contracts.Infrastructure;
using ShawContract.Application.Models;
using System.Collections.Generic;

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