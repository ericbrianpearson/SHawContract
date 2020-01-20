using ShawContract.Application.Contracts.Gateways;
using ShawContract.Application.Models;
using ShawContract.Providers.Kentico.PageHandler;
using System.Linq;

namespace ShawContract.Providers.Kentico
{
    public class GenericContentGateway : IGenericContentGateway
    {
        private IPageContentHandler PageContentHandler { get; }

        public GenericContentGateway(IPageContentHandler pageContentHandler)
        {
            this.PageContentHandler = pageContentHandler;
        }

        public GenericContentPage GetGenericContentPage(string pageAlias)
        {
            return this.PageContentHandler.GetPage<CMS.DocumentEngine.Types.ShawContract.GenericContent>(pageAlias)
                    .AddColumns("DocumentID", "Title", "CustomCSSClass")
                    .ToList()
                    .Select(l => new GenericContentPage()
                    {
                        DocumentId = l.DocumentID,
                        Title = l.Title,
                        CustomCSSClass = l.CustomCSSClass
                    })
                    .FirstOrDefault();
        }
    }
}