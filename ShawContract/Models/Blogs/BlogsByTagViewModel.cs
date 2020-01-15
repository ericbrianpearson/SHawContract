using ShawContract.Application.Models;
using System.Collections.Generic;

namespace ShawContract.Models.Blogs
{
    public class BlogsByTagViewModel : IViewModel
    {
        public IEnumerable<BlogPreview> Articles { get; set; }
        public CtaDto Cta { get; set; }
        public string SelectedTag { get; set; }
    }
}