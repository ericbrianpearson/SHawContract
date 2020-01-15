using ShawContract.Application.Models;
using System.Collections.Generic;

namespace ShawContract.Models.Blogs
{
    public class BlogArticlesViewModel
    {
        public string NodeAlias { get; set; }
        public List<BlogPreview> Articles { get; set; }
    }
}