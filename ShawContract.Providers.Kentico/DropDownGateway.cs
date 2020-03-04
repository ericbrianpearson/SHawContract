using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using AutoMapper;
using CMS.DocumentEngine;
using ShawContract.Application.Contracts.Gateways;
using ShawContract.Application.Models;
using ShawContract.Providers.Kentico.PageHandler;

namespace ShawContract.Providers.Kentico
{
    public class ContactUsGateway : IContactUsGateway
    {
        private const string dropDownItemsKey = "DropDownItemsKey";
        private IPageContentHandler PageContentHandler { get; }
        private IMapper Mapper { get; }
        public ContactUsGateway(IPageContentHandler pageContentHandler, IMapper mapper)
        {
            this.PageContentHandler = pageContentHandler;
            this.Mapper = mapper;
        }

        public IEnumerable<ContactUsMenu> GetDropDowns(string nodeAlias)
        {
            var path = string.Format("/{0}/", nodeAlias);
            var dropDownItems = PageContentHandler.GetPages<CMS.DocumentEngine.Types.ShawContract.ContactPageMenu>()
            .Path(path, PathTypeEnum.Children)
            .AddColumns("Title", "menuType")
            .OrderByAscending("NodeOrder")
            .NestingLevel(2)
            .ToList();

            var dropdowns = Mapper.Map<IEnumerable<ContactUsMenu>>(dropDownItems);
            foreach (var dropDown in dropdowns)
            {
                dropDown.Items = GetItems(nodeAlias, dropDown.Title);

            }
            return dropdowns;
        }

        private IEnumerable<ContactUsMenuItem> GetItems(string nodeAlias, string title)
        {
            var formattedTitle = Regex.Replace(title, @"\p{P}", "").Replace(" ", "-");
          
            var path = string.Format("/{0}/{1}", nodeAlias, formattedTitle);

            var dropDownItems = PageContentHandler.GetPages<CMS.DocumentEngine.Types.ShawContract.ContactPageMenuItem>()
                .Path(path, PathTypeEnum.Children)
                .AddColumns("Title")
                .OrderByAscending("NodeOrder")
                .Where(i => i.NodeLevel == 3)
                .ToList();

            return Mapper.Map<IEnumerable<ContactUsMenuItem>>(dropDownItems);
        }
    }
}
