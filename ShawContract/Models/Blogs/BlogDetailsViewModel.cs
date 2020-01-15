using ShawContract.Application.Models;

namespace ShawContract.Models.Blogs
{
    public class BlogDetailsViewModel : IViewModel
    {
        public Blog Article { get; set; }
    }
}