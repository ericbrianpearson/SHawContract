using ShawContract.Infrastructure;
using ShawContract.Providers.Kontent.KontentHandler;

namespace Shaw.Contract.UnitTests.Mocks
{
    public static class MockedKontentProvider
    {
        public static KontentDeliveryClient GetKontentProvider()
        {
            return new KontentDeliveryClient(new KontentConfiguration(new ConfigurationService()));
        }
    }
}