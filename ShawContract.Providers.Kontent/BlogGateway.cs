using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Kentico.Kontent.Delivery;
using ShawContract.Application.Contracts.Gateways;
using ShawContract.Application.Contracts.Infrastructure;
using ShawContract.Application.Models;
using ShawContract.Providers.Kontent.Interfaces;
using ShawContract.Providers.Kontent.Models;

namespace ShawContract.Providers.Kontent
{
    public class BlogGateway : IBlogGateway
    {
        private IKontentDeliveryClient KontentDeliveryClient { get; }
        private ISiteContextService SiteContext { get; }

        public BlogGateway(IKontentDeliveryClient kontentDeliveryClient, ISiteContextService siteContextService)
        {
            KontentDeliveryClient = kontentDeliveryClient;
            SiteContext = siteContextService;
        }

        public async Task<IEnumerable<Blog>> GetAllBlogsAsync()
        {
            DeliveryItemListingResponse<BlogEntry> response = await KontentDeliveryClient.DeliveryClient.GetItemsAsync<BlogEntry>(
                new EqualsFilter("system.type", "blog_entry"),
                new LanguageParameter(SiteContext.CurrentSiteCulture),
                new EqualsFilter("system.language", SiteContext.CurrentSiteCulture),
                new OrderParameter("system.last_modified", SortOrder.Descending)
                );

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BlogEntry, Blog>()
                 .ForMember(dest => dest.LongDescription, opts => opts.MapFrom(src => src.ArticleBaseSnippetLongDescription))
                 .ForMember(dest => dest.SeoFriendlyName, opts => opts.MapFrom(src => src.ArticleBaseSnippetSeoFriendlyName))
                 .ForMember(dest => dest.SeoUrl, opts => opts.MapFrom(src => src.ArticleBaseSnippetSeoUrl))
                 .ForMember(dest => dest.ShortDescription, opts => opts.MapFrom(src => src.ArticleBaseSnippetShortDescription))
                 .ForMember(dest => dest.SubTitle, opts => opts.MapFrom(src => src.ArticleBaseSnippetSubTitle))
                 .ForMember(dest => dest.Title, opts => opts.MapFrom(src => src.ArticleBaseSnippetTitle));
            });
            var mapper = config.CreateMapper();

            return mapper.Map<IEnumerable<BlogEntry>, IEnumerable<Blog>>(response.Items);
        }
    }
}