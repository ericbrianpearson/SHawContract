using ShawContract.Application.Models;

namespace ShawContract.Application.Contracts.Gateways
{
    public interface IContactGateway
    {
        ContactPage GetContactPage(string nodeAlias);
    }
}
