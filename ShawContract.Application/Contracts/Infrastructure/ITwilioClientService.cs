using Twilio.TwiML;

namespace ShawContract.Application.Contracts.Infrastructure
{
    public interface ITwilioClientService : ICommunicationService<TwiML>
    {
        void InitilizeTwilio();
    }
}