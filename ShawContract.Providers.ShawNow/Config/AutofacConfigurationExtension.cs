using Autofac;
using ShawContract.Application.Contracts.Services;

namespace ShawContract.Providers.ShawNow.Config
{
    public static class AutofacConfigurationExtension
    {
        public static ContainerBuilder RegisterShawNowServices(this ContainerBuilder builder)
        {
            builder.RegisterType<SendOrderService>().As<ISendOrderService>()
               .InstancePerRequest();

            builder.RegisterType<OrderBuilder>().As<IOrderBuilder>()
                .InstancePerRequest();
            builder.RegisterType<StockCheckService>().As<IStockCheckService>()
                .InstancePerRequest();

            return builder;
        }
    }
}