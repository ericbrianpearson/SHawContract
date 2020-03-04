using ShawContract.Application.Contracts.Gateways;
using ShawContract.Application.Contracts.Infrastructure;
using ShawContract.Application.Contracts.Services;
using ShawContract.Application.Models;
using System.Linq;

namespace ShawContract.Application.Services
{
    public class HomePageService : IHomePageService
    {
        private const string HomePageCachingKey = "HomePageCachingKey";

        public HomePageService(IHomePageGateway homePageGateway, ICarouselGateway carouselGateway, ICachingService cachingService)
        {
            this.HomePageGateway = homePageGateway;
            this.CarouselGateway = carouselGateway;
            this.CachingService = cachingService;
        }

        private ICachingService CachingService { get; }

        private ICarouselGateway CarouselGateway { get; }

        private IHomePageGateway HomePageGateway { get; }

        public HomePage GetHomePage()
        {
            return CachingService.GetOrCreateItem<HomePage>(HomePageCachingKey, () =>
            {
                var page = this.HomePageGateway.GetHomePage();
                if (page != null && !string.IsNullOrEmpty(page.Title))
                {
                    page.CarouselSections = this.CarouselGateway.GetCarouselSections(page.Title).ToList();
                }

                return page;
            });
        }
    }
}
