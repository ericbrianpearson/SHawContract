using ShawContract.Application.Models;

namespace ShawContract.Application.Contracts.Gateways
{
    public interface IAccountGateway
    {
        Account GetAccount();
    }
}