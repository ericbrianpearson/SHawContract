using Autofac;
using CMS.Ecommerce;
using ShawContract.Application.Contracts.Gateways;
using ShawContract.Application.Contracts.Services;
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

            builder.RegisterType<ContactUsGateway>().As<IContactUsGateway>()
                .InstancePerRequest();

            builder.RegisterType<ContactGateway>().As<IContactGateway>()
                .InstancePerRequest();

            builder.RegisterType<BlogPageGateway>().As<IBlogPageGateway>()
                .InstancePerRequest();

            builder.RegisterType<ProductGateway>().As<IProductGateway>()
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
            builder.RegisterType<ShoppingService>().As<IShoppingService>()
             .InstancePerRequest();
            builder.RegisterType<HomePageGateway>().As<IHomePageGateway>()
                .InstancePerRequest();
            builder.RegisterType<CarouselGateway>().As<ICarouselGateway>()
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