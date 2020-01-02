namespace ShawContract.Application.Contracts.Infrastructure
{
    public interface ICommunicationService<T>
    {
        void Call(string phoneNumber);

        T ConstructVoiceResponse();

        T ConstructMessageResponse();
    }
}