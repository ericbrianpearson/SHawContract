using Autofac;
using ShawContract.Application.Contracts.Gateways;
using ShawContract.Providers.ProductBoard.DAL;

namespace ShawContract.Providers.ProductBoard.Config
{
    public static class AutofacConfigurationExtension
    {
        public static ContainerBuilder RegisterProductBoardServices(this ContainerBuilder builder)
        {           
            builder.RegisterType<ProductBoardContext>().As<IProductBoardContext>()
             .InstancePerRequest();
            builder.RegisterType<ProductBoardGateway>().As<IProductBoardGateway>()
                .InstancePerRequest();

            return builder;
        }
    }
}