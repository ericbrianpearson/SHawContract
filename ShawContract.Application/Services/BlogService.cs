using ShawContract.Application.Contracts.Gateways;
using ShawContract.Application.Contracts.Infrastructure;
using ShawContract.Application.Contracts.Services;
using ShawContract.Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShawContract.Application.Services
{
    public class BlogService : IBlogService
    {
        private const string BlogsCachingKey = "BlogsCachingKey";

        public BlogService(IBlogGateway blogGateway, IBlogPageGateway blogPage, ICachingService cachingService)
        {
            this.BlogGateway = blogGateway;
            this.BlogPage = blogPage;
            this.CachingService = cachingService;
        }

        //Getting the page itself
        public IBlogPageGateway BlogPage { get; }

        private IBlogGateway BlogGateway { get; }

        private ICachingService CachingService { get; }

        public async Task<IEnumerable<BlogPreview>> FilterByTagsAsync(string persona, string segment)
        {
            return await CachingService.GetOrCreateItemAsync(BlogsCachingKey + persona + segment,
                async () => await this.BlogGateway.FilterByTagsAsync(persona, segment));
        }

        public async Task<IEnumerable<BlogPreview>> GetAllBlogsAsync()
        {
            return await CachingService.GetOrCreateItemAsync(BlogsCachingKey,
                async () => await this.BlogGateway.GetAllBlogsAsync());
        }

        public async Task<Blog> GetBlogAsync(string seoUrl)
        {
            return await CachingService.GetOrCreateItemAsync(BlogsCachingKey + seoUrl,
               async () => await this.BlogGateway.GetBlogAsync(seoUrl));
        }

        public BlogPage GetPage(string nodeAlias)
        {
            return CachingService.GetOrCreateItem(BlogsCachingKey + nodeAlias,
               () => this.BlogPage.GetBlogPage(nodeAlias));
        }

        public async Task<IEnumerable<BlogPreview>> GetTaggedArticlesAsync(string tagType, string tag)
        {
            return await CachingService.GetOrCreateItemAsync(BlogsCachingKey + tagType + tag,
                async () => string.Compare(tagType.ToLower(), "articlebasesnippetpersonas") == 0 ? await BlogGateway.ArticlesByPersonaAsync(tag) : await BlogGateway.ArticlesBySegmentAsync(tag));
        }

        public async Task<Taxonomy> GetTaxonomyTermsAsync()
        {
            return await CachingService.GetOrCreateItemAsync(BlogsCachingKey + "Taxonomy",
                async () => await this.BlogGateway.GetTaxonomyAsync());
        }
    }
}
