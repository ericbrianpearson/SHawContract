using ShawContract.Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ShawContract.Application.Contracts.Gateways
{
    public interface IBlogGateway
    {
        Task<IEnumerable<BlogPreview>> GetAllBlogsAsync();
        Task<Blog> GetBlogAsync(string seoUrl);
        Task<Taxonomy> GetTaxonomyAsync();
        Task<IEnumerable<BlogPreview>> FilterByTagsAsync(string persona, string segment);
        Task<IEnumerable<BlogPreview>> ArticlesByPersonaAsync(string persona);
        Task<IEnumerable<BlogPreview>> ArticlesBySegmentAsync(string segment);
    }
}