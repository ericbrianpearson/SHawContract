using ShawContract.Application.Contracts.Gateways;
using ShawContract.Application.Models;
using ShawContract.Providers.Kentico.PageHandler;
using System.Linq;

namespace ShawContract.Providers.Kentico
{
    
    public class HomePageGateway: IHomePageGateway
    {
        private IPageContentHandler PageContentHandler { get; }

        public HomePageGateway(IPageContentHandler contentHandler)
        {
            this.PageContentHandler = contentHandler;
        }
        public HomePage GetHomePage()
        {
            return this.PageContentHandler.GetPages<CMS.DocumentEngine.Types.ShawContract.HomePage>()
                    .AddColumns("DocumentID", "Title")
                    .ToList()
                    .Select(l => new HomePage()
                    {
                        DocumentID = l.DocumentID,
                        Title = l.Title
                    })
                    .FirstOrDefault();
        }
    }
}
