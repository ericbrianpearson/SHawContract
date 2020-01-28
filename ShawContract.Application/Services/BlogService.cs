using System.Collections.Generic;
using System.Threading.Tasks;
using ShawContract.Application.Contracts.Gateways;
using ShawContract.Application.Contracts.Services;
using ShawContract.Application.Models;

namespace ShawContract.Application.Services
{
    public class BlogService : IBlogService
    {
        private IBlogGateway BlogGateway { get; }
        
        //Getting the page itself
        public IBlogPageGateway BlogPage { get; }

        public BlogService(IBlogGateway blogGateway, IBlogPageGateway blogPage)
        {
            this.BlogGateway = blogGateway;
            this.BlogPage = blogPage;
        }



        public async Task<IEnumerable<BlogPreview>> GetAllBlogsAsync()
        {
            return await this.BlogGateway.GetAllBlogsAsync();
        }

        public async Task<Blog> GetBlogAsync(string seoUrl)
        {
            return await this.BlogGateway.GetBlogAsync(seoUrl);
        }

        public async Task<Taxonomy> GetTaxonomyTermsAsync()
        {
            return await this.BlogGateway.GetTaxonomyAsync();
        }

        public async Task<IEnumerable<BlogPreview>> FilterByTagsAsync(string persona, string segment)
        {
            return await this.BlogGateway.FilterByTagsAsync(persona, segment);
        }

        public async Task<IEnumerable<BlogPreview>> GetTaggedArticlesAsync(string tagType, string tag)
        {     
            
            return string.Compare(tagType.ToLower(), "articlebasesnippetpersonas") == 0 ? await BlogGateway.ArticlesByPersonaAsync(tag) : await BlogGateway.ArticlesBySegmentAsync(tag);
        }

        public BlogPage GetPage(string nodeAlias)
        {
            return this.BlogPage.GetBlogPage(nodeAlias);
        }
    }
}