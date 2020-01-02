using ShawContract.Application.Contracts.Gateways;
using ShawContract.Application.Contracts.Services;
using ShawContract.Application.Models;

namespace ShawContract.Application.Services
{
    public class GenericContentPageService : IGenericContentPageService
    {
        private IGenericContentGateway GenericContentGateway { get; }

        public GenericContentPageService(IGenericContentGateway genericContentGateway)
        {
            this.GenericContentGateway = genericContentGateway;
        }

        public GenericContentPage GetGenericContentPage(string pageAlias)
        {
            return this.GenericContentGateway.GetGenericContentPage(pageAlias);
        }
    }
}