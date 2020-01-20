using ShawContract.Application.Models;
using System.Collections.Generic;

namespace ShawContract.Models
{
    public class PageViewModel
    {
        public PageMetadata Metadata { get; set; }
        public IEnumerable<MenuItem> HeaderMenuItems { get; set; }
        public IEnumerable<MenuItem> SecondaryMenuItems { get; set; }
        public IEnumerable<MenuItem> FooterMenuItems { get; set; }
        public IEnumerable<CultureInfo> Cultures { get; set; }
    }

    public class PageViewModel<TViewModel> : PageViewModel where TViewModel : IViewModel
    {
        public TViewModel Data { get; set; }
    }
}