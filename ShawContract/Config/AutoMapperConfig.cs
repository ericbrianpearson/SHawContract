using AutoMapper;
using CMS.Personas;
using ShawContract.Application.Models;
using ShawContract.Models.Widgets.BulletListWidget;
using ShawContract.Providers.Kontent.Models;
using System.Linq;

namespace ShawContract.Config
{
    public static class AutoMapperConfig
    {
        public static IMapper RegisterAutoMappings()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BulletListWidgetProperties, BulletListWidgetViewModel>();

                //Kentico mappings
                cfg.CreateMap<CMS.DocumentEngine.Types.ShawContract.MenuItem, MenuItem>();
                cfg.CreateMap<PersonaInfo, Persona>();

                //Product Boards
                cfg.CreateMap<Providers.ProductBoard.Models.ProductBoardItem, ShawContract.Application.Models.ProductBoardItem>();
                cfg.CreateMap<ProductBoardItem, Providers.ProductBoard.Models.ProductBoardItem>();
                cfg.CreateMap<Providers.ProductBoard.Models.ProductBoard, ShawContract.Application.Models.ProductBoard>()
                .ForMember(dest => dest.ProductBoardItems,
                opts => opts.MapFrom(src => src.ProductBoardItems));

                cfg.CreateMap<ProductBoard, Providers.ProductBoard.Models.ProductBoard>();

                //Taxonomy terms
                cfg.CreateMap<TaxonomyTypes, Taxonomy>();
                cfg.CreateMap<Kentico.Kontent.Delivery.TaxonomyTerm, TaxonomyTermDto>();
                cfg.CreateMap<TaxonomyTerm, TaxonomyTermDto>();

                //Kontent
                cfg.CreateMap<WidenImage, ImageDto>();
                cfg.CreateMap<BlogEntry, BlogPreview>()
                 .ForMember(dest => dest.Image, opts => opts.MapFrom(src => src.ArticleBaseSnippetImageMedia.FirstOrDefault()))
                 .ForMember(dest => dest.SeoUrl, opts => opts.MapFrom(src => src.ArticleBaseSnippetSeoUrl))
                 .ForMember(dest => dest.ShortDescription, opts => opts.MapFrom(src => src.ArticleBaseSnippetShortDescription))
                 .ForMember(dest => dest.Subtitle, opts => opts.MapFrom(src => src.ArticleBaseSnippetSubTitle))
                 .ForMember(dest => dest.Title, opts => opts.MapFrom(src => src.ArticleBaseSnippetTitle))
                 .ForMember(dest => dest.Cta, opts => opts.MapFrom(src => src.PlaceholderCta.FirstOrDefault()));

                cfg.CreateMap<Cta, CtaDto>();
                cfg.CreateMap<BlogEntry, Blog>()
                    .ForMember(dest => dest.Title, opts => opts.MapFrom(src => src.ArticleBaseSnippetTitle))
                    .ForMember(dest => dest.SubTitle, opts => opts.MapFrom(src => src.ArticleBaseSnippetSubTitle))
                    .ForMember(dest => dest.SeoFriendlyName, opts => opts.MapFrom(src => src.ArticleBaseSnippetSeoFriendlyName))
                    .ForMember(dest => dest.SeoUrl, opts => opts.MapFrom(src => src.ArticleBaseSnippetSeoUrl))
                    .ForMember(dest => dest.ShortDescription, opts => opts.MapFrom(src => src.ArticleBaseSnippetShortDescription))
                    .ForMember(dest => dest.MainImage, opts => opts.MapFrom(src => src.ArticleBaseSnippetImageMedia.FirstOrDefault()))
                    .ForMember(dest => dest.PlaceHolderCTA, opts => opts.MapFrom(src => src.PlaceholderCta.FirstOrDefault()))
                    .ForMember(dest => dest.LongDescription, opts => opts.MapFrom(src => src.ArticleBaseSnippetLongdescription));

                cfg.CreateMap<ShoppingCartInfo, ShoppingCart>();
                cfg.CreateMap<ShoppingCartItemInfo, ShoppingCartItem>()
                            .ForMember(dest => dest.CartItemName,
                            opts => opts.MapFrom(src => src.SKU.SKUName));
            });

            return config.CreateMapper();
        }
    }
}