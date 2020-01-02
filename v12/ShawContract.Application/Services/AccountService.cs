using ShawContract.Application.Contracts.Gateways;
using ShawContract.Application.Contracts.Services;
using ShawContract.Application.Models;

namespace ShawContract.Application.Services
{
    public class AccountService : IAccountService
    {
        private IAccountGateway AccountGateway { get; }

        public AccountService(IAccountGateway accountGateway)
        {
            this.AccountGateway = accountGateway;
        }

        public Account GetAccount()
        {
            return this.AccountGateway.GetAccount();
        }
    }
}