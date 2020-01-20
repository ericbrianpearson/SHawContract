using CMS.DocumentEngine.Types.ShawContract;
using ShawContract.Application.Contracts.Gateways;
using ShawContract.Application.Models;
using ShawContract.Providers.Kentico.PageHandler;
using System.Linq;

namespace ShawContract.Providers.Kentico
{
    public class AccountGateway : IAccountGateway
    {
        private IPageContentHandler PageContentHandler { get; }

        public AccountGateway(IPageContentHandler pageContentHandler)
        {
            this.PageContentHandler = pageContentHandler;
        }

        public Account GetAccount()
        {
            return this.PageContentHandler.GetPages<AccountPage>()
                    .AddColumns("Title", "CustomCSSClass")
                    .ToList()
                    .Select(a => new Account()
                    {
                        Title = a.Title,
                        CustomCSSClass = a.CustomCSSClass
                    })
                    .FirstOrDefault();
        }
    }
}