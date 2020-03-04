using ShawContract.Application.Contracts.Gateways;
using ShawContract.Application.Models;
using ShawContract.Providers.Kentico.PageHandler;
using System.Linq;

namespace ShawContract.Providers.Kentico
{
    public class ContactGateway : IContactGateway
    {
        private IPageContentHandler ContentHandler { get; }

        public ContactGateway(IPageContentHandler contentHandler)
        {
            this.ContentHandler = contentHandler;
        }

        public ContactPage GetContactPage(string nodeAlias)
        {
            return this.ContentHandler.GetPage<CMS.DocumentEngine.Types.ShawContract.ContactPage>(nodeAlias)
                    .AddColumns("DocumentID")
                    .ToList()
                    .Select(l => new ContactPage()
                    {
                        DocumentID = l.DocumentID
                    })
                    .FirstOrDefault();
        }
    }
}
