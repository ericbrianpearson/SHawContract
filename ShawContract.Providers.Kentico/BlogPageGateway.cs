using ShawContract.Application.Contracts.Gateways;
using ShawContract.Application.Models;
using ShawContract.Providers.Kentico.PageHandler;
using System.Linq;

namespace ShawContract.Providers.Kentico
{
    public class BlogPageGateway : IBlogPageGateway
    {
        private IPageContentHandler PageContentHandler { get; }

        public BlogPageGateway(IPageContentHandler pageContentHandler)
        {
            this.PageContentHandler = pageContentHandler;
        }

        public BlogPage GetBlogPage(string nodeAlias)
        {
            return this.PageContentHandler.GetPage<CMS.DocumentEngine.Types.ShawContract.BlogPage>(nodeAlias)
                    .AddColumns("DocumentID")
                    .ToList()
                    .Select(l => new BlogPage()
                    {
                        DocumentID = l.DocumentID
                    })
                    .FirstOrDefault();
        }
    }
}
