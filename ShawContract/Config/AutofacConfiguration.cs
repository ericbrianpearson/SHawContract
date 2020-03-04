using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using ShawContract.Application.Contracts.Infrastructure;
using ShawContract.Application.Contracts.Services;
using ShawContract.Application.Services;
using ShawContract.Infrastructure;
using ShawContract.Providers.Kentico;
using ShawContract.Providers.Kontent.Config;
using ShawContract.Providers.ProductBoard.Config;
using ShawContract.Providers.ShawNow.Config;
using ShawContract.Utils;
using System.Globalization;
using System.Web.Mvc;

namespace ShawContract.Config
{
    public class AutofacConfiguration
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            // Register dependencies in controllers
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.Register(c => AutoMapperConfig.RegisterAutoMappings()).As<IMapper>()
                .InstancePerRequest();

            builder.RegisterType<ContactUsService>().As<IContactUsService>()
                .InstancePerRequest();

            builder.RegisterType<MailingClientService>().As<IMailingClientService>()
                .InstancePerRequest();

            builder.RegisterType<MailingService>().As<IMailingService>()
                .InstancePerRequest();

            builder.RegisterType<ContactService>().As<IContactService>()
                .InstancePerRequest();

            builder.RegisterType<PersonaService>().As<IPersonaService>()
              .InstancePerRequest();

            builder.RegisterType<MasterPageService>().As<IMasterPageService>()
               .InstancePerRequest();

            builder.RegisterType<AccountService>().As<IAccountService>()
               .InstancePerRequest();

            builder.RegisterType<GenericContentPageService>().As<IGenericContentPageService>()
               .InstancePerRequest();

            builder.RegisterType<ShoppingCartService>().As<IShoppingCartService>()
                .InstancePerRequest();

            builder.RegisterType<ConfigurationService>().As<IConfigurationService>()
                .SingleInstance();

            builder.RegisterType<TwilioClientService>().As<ITwilioClientService>()
                .SingleInstance();

            builder.RegisterType<CachingService>().As<ICachingService>()
                .SingleInstance();

            builder.RegisterType<LoggingService>().As<ILoggingService>()
                .SingleInstance();
            builder.RegisterType<ProductBoardService>().As<IProductBoardService>()
                .InstancePerRequest();

            builder.RegisterType<ProductService>().As<IProductsService>()
               .InstancePerRequest();

            builder.RegisterType<HomePageService>().As<IHomePageService>()
              .InstancePerRequest();

            builder.RegisterType<SiteContextService>().As<ISiteContextService>()
                .WithParameter((parameter, context) => parameter.Name == "currentCulture",
                    (parameter, context) => CultureInfo.CurrentUICulture.Name)
                .WithParameter((parameter, context) => parameter.Name == "siteName",
                    (parameter, context) => AppConfig.Sitename)
                .WithProperty("SiteContextID", 1)
                .InstancePerRequest();

            builder.RegisterKenticoServices();
            builder.RegisterKenticoSources();
            builder.RegisterProductBoardServices();
            builder.RegisterKontentServices();
            builder.RegisterShawNowServices();

            // Set MVC DI resolver to use our Autofac container
            DependencyResolver.SetResolver(new AutofacDependencyResolver(builder.Build()));
        }
    }
}