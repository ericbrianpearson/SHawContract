using Autofac;
using ShawContract.Application.Contracts.Gateways;

using ShawContract.Providers.Kentico.PageHandler;

namespace ShawContract.Providers.Kentico
{
    public static class AutofacConfigurationExtension
    {
        public static ContainerBuilder RegisterKenticoServices(this ContainerBuilder builder)
        {
            builder.RegisterType<GenericContentGateway>().As<IGenericContentGateway>()
             .InstancePerRequest();
            builder.RegisterType<MediaLibraryFileGateway>().As<IMediaLibraryGateway>()
                .InstancePerRequest();

            builder.RegisterType<PersonaGateway>().As<IPersonaGateway>()
             .InstancePerRequest();
            builder.RegisterType<AccountGateway>().As<IAccountGateway>()
               .InstancePerRequest();
            builder.RegisterType<CultureInfoGateway>().As<ICultureInfoGateway>()
               .InstancePerRequest();
            builder.RegisterType<MenuGateway>().As<IMenuGateway>()
               .InstancePerRequest();
            builder.RegisterType<ShoppingCartGateway>().As<IShoppingCartGateway>()
                .InstancePerRequest();
            builder.RegisterType<PageContentHandler>().As<IPageContentHandler>()
              .InstancePerRequest();

            return builder;
        }

        public static ContainerBuilder RegisterKenticoSources(this ContainerBuilder builder)
        {
            builder.RegisterSource(new CMSRegistrationSource());

            return builder;
        }
    }
}