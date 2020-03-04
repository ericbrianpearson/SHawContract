using ShawContract.Application.Models;

namespace ShawContract.Application.Contracts.Infrastructure
{
    public interface IMailingClientService
    {
        void SendMail(ContactUsEmail email);
    }
}
