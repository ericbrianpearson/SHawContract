using ShawContract.Application.Models;

namespace ShawContract.Application.Contracts.Gateways
{
    public interface IGenericContentGateway
    {
        GenericContentPage GetGenericContentPage(string pageAlias);
    }
}