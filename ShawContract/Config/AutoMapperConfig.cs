using AutoMapper;
using CMS.Personas;
using ShawContract.Application.Models;
using ShawContract.Models.Widgets.BulletListWidget;

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
                cfg.CreateMap<Providers.ProductBoard.Models.ProductBoardItem, ProductBoardItem>();
                cfg.CreateMap<ProductBoardItem, Providers.ProductBoard.Models.ProductBoardItem>();
                cfg.CreateMap<Providers.ProductBoard.Models.ProductBoard, ProductBoard>()
                .ForMember(dest => dest.ProductBoardItems,
                opts => opts.MapFrom(src => src.ProductBoardItems));

                cfg.CreateMap<ProductBoard, Providers.ProductBoard.Models.ProductBoard>();
            });

            return config.CreateMapper();
        }
    }
}