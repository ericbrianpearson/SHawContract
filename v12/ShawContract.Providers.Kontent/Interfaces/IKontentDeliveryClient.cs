using Kentico.Kontent.Delivery;

namespace ShawContract.Providers.Kontent.Interfaces
{
    public interface IKontentDeliveryClient
    {
        IDeliveryClient DeliveryClient { get; }
    }
}