using System.Collections.Generic;
using System.Threading.Tasks;
using ShawContract.Application.Models;
using ShawContract.Application.Contracts.Gateways;

namespace ShawContract.Application.Contracts.Services
{
    public interface IBlogService
    {
        Task<IEnumerable<BlogPreview>> GetAllBlogsAsync();
        Task<Blog> GetBlogAsync(string seoUrl);
        Task<Taxonomy> GetTaxonomyTermsAsync();
        Task<IEnumerable<BlogPreview>> FilterByTagsAsync(string persona, string segment);
        Task<IEnumerable<BlogPreview>> GetTaggedArticlesAsync(string tagType, string tag);
        BlogPage GetPage(string nodeAlias);
    }
}