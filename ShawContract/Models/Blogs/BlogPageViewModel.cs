using ShawContract.Application.Models;
using System.Collections.Generic;

namespace ShawContract.Models.Blogs
{
    public class BlogPageViewModel : IViewModel
    {
        public IEnumerable<TaxonomyTermDto> Personas { get; set; }
        public IEnumerable<TaxonomyTermDto> Segments { get; set; }
        public IEnumerable<BlogPreview> Articles { get; set; }
    }
}