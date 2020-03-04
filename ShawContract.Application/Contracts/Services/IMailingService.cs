using ShawContract.Application.Models;

namespace ShawContract.Application.Contracts.Services
{
    public interface IMailingService
    {
        void SendEmail(ContactUsEmail email);
    }
}
