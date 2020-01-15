using Autofac;
using ShawContract.Application.Contracts.Gateways;
using ShawContract.Application.Contracts.Services;
using ShawContract.Application.Services;
using ShawContract.Providers.Kontent.Interfaces;
using ShawContract.Providers.Kontent.KontentHandler;

namespace ShawContract.Providers.Kontent.Config
{
    public static class AutofacConfigurationExtensioncs
    {
        public static ContainerBuilder RegisterKontentServices(this ContainerBuilder builder)
        {
            builder.RegisterType<KontentDeliveryClient>().As<IKontentDeliveryClient>()
                .InstancePerRequest();

            builder.RegisterType<KontentConfiguration>().As<IKontentConfiguration>()
                .InstancePerRequest();

            builder.RegisterType<BlogService>().As<IBlogService>()
                .InstancePerRequest();

            builder.RegisterType<BlogGateway>().As<IBlogGateway>()
                .InstancePerRequest();

            return builder;
        }
    }
}
