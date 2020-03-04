using AutoMapper;
using CMS.DocumentEngine;
using ShawContract.Application.Contracts.Gateways;
using ShawContract.Application.Models;
using ShawContract.Providers.Kentico.PageHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ShawContract.Providers.Kentico
{
    public class CarouselGateway : ICarouselGateway
    {
        private IPageContentHandler PageContentHandler { get; }
        private IMapper Mapper { get; }
        public CarouselGateway(IPageContentHandler pageContentHandler, IMapper mapper)
        {
            this.PageContentHandler = pageContentHandler;
            this.Mapper = mapper;
        }

        public IEnumerable<CarouselSection> GetCarouselSections(string nodeAlias)
        {
            var path = string.Format("/{0}/", nodeAlias);
            var sections = PageContentHandler.GetPages<CMS.DocumentEngine.Types.ShawContract.CarouselSection>()
            .Path(path, PathTypeEnum.Children)
            .AddColumns("DocumentName","IsLarge")
            .OrderByAscending("NodeOrder")
            .NestingLevel(2)
            .ToList();

            var carouselSections = Mapper.Map<IEnumerable<CarouselSection>>(sections);
            foreach (var section in carouselSections)
            {
                section.CarouselItems = GetItems(nodeAlias, section.Title).ToList();

            }
            return carouselSections;
        }
        private IEnumerable<CarouselItem> GetItems(string nodeAlias, string title)
        {
            var formattedTitle = Regex.Replace(title, @"\p{P}", "").Replace(" ", "-");

            var path = string.Format("/{0}/{1}", nodeAlias, formattedTitle);

            var items = PageContentHandler.GetPages<CMS.DocumentEngine.Types.ShawContract.CarouselItem>()
                .Path(path, PathTypeEnum.Children)
                .AddColumns("Title", "Subtitle", "ImageUrl1", "ImageUrl2", "ButtonText", "ButtonUrl", "PhotoCredit")
                .OrderByAscending("NodeOrder")
                .Where(i => i.NodeLevel == 3)
                .ToList();
            
            return Mapper.Map<IEnumerable<CarouselItem>>(items);
        }
    }
}
