using AutoMapper;
using Kentico.Kontent.Delivery;
using ShawContract.Application.Contracts.Gateways;
using ShawContract.Application.Contracts.Infrastructure;
using ShawContract.Application.Models;
using ShawContract.Providers.Kontent.Interfaces;
using ShawContract.Providers.Kontent.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShawContract.Providers.Kontent
{
    public class BlogGateway : IBlogGateway
    {
        public BlogGateway(IKontentDeliveryClient kontentDeliveryClient, ISiteContextService siteContextService, IMapper mapper)
        {
            KontentDeliveryClient = kontentDeliveryClient;
            SiteContext = siteContextService;
            Mapper = mapper;
        }

        private IKontentDeliveryClient KontentDeliveryClient { get; }

        private IMapper Mapper { get; }

        private ISiteContextService SiteContext { get; }

        public async Task<IEnumerable<BlogPreview>> ArticlesByPersonaAsync(string persona)
        {
            DeliveryItemListingResponse<BlogEntry> response = await KontentDeliveryClient.DeliveryClient
                .GetItemsAsync<BlogEntry>(
                new DepthParameter(3),
                new EqualsFilter("system.type", "blog_entry"),
                new LanguageParameter(SiteContext.CurrentSiteCulture.ToLowerInvariant()),
                new EqualsFilter("system.language", SiteContext.CurrentSiteCulture.ToLowerInvariant()),
                new ContainsFilter("elements.article_base_snippet__personas", persona),
                new OrderParameter("system.last_modified", SortOrder.Descending)
                );

            var casted = response.Items.Cast<BlogEntry>();
            var mapped = Mapper.Map<IEnumerable<BlogEntry>, IEnumerable<BlogPreview>>(response.Items);
            return mapped;
        }

        public async Task<IEnumerable<BlogPreview>> ArticlesBySegmentAsync(string segment)
        {
            DeliveryItemListingResponse<BlogEntry> response = await KontentDeliveryClient.DeliveryClient
                .GetItemsAsync<BlogEntry>(
                new DepthParameter(3),
                new EqualsFilter("system.type", "blog_entry"),
                new LanguageParameter(SiteContext.CurrentSiteCulture.ToLowerInvariant()),
                new EqualsFilter("system.language", SiteContext.CurrentSiteCulture.ToLowerInvariant()),
                new ContainsFilter("elements.article_base_snippet__segments", segment),
                new OrderParameter("system.last_modified", SortOrder.Descending)
                );

            var mapped = Mapper.Map<IEnumerable<BlogEntry>, IEnumerable<BlogPreview>>(response.Items);
            return mapped;
        }

        public async Task<IEnumerable<BlogPreview>> FilterByTagsAsync(string persona, string segment)
        {
            DeliveryItemListingResponse<BlogEntry> response = await KontentDeliveryClient.DeliveryClient
                .GetItemsAsync<BlogEntry>(
                new DepthParameter(3),
                new EqualsFilter("system.type", "blog_entry"),
                new LanguageParameter(SiteContext.CurrentSiteCulture.ToLowerInvariant()),
                new EqualsFilter("system.language", SiteContext.CurrentSiteCulture.ToLowerInvariant()),
                new ContainsFilter("elements.article_base_snippet__segments", segment),
                new ContainsFilter("elements.article_base_snippet__personas", persona),
                new OrderParameter("system.last_modified", SortOrder.Descending)
                );

            var mapped = Mapper.Map<IEnumerable<BlogEntry>, IEnumerable<BlogPreview>>(response.Items);
            return mapped;
        }

        public async Task<IEnumerable<BlogPreview>> GetAllBlogsAsync()
        {
            DeliveryItemListingResponse<BlogEntry> response = await KontentDeliveryClient.DeliveryClient
                .GetItemsAsync<BlogEntry>(
                new DepthParameter(3),
                new EqualsFilter("system.type", "blog_entry"),
                new LanguageParameter(SiteContext.CurrentSiteCulture.ToLowerInvariant()),
                new EqualsFilter("system.language", SiteContext.CurrentSiteCulture.ToLowerInvariant()),
                new OrderParameter("system.last_modified", SortOrder.Descending)
                );

            var mapped = Mapper.Map<IEnumerable<BlogEntry>, IEnumerable<BlogPreview>>(response.Items);
            return mapped;
        }

        public async Task<Blog> GetBlogAsync(string seoUrl)
        {
            var response = await KontentDeliveryClient.DeliveryClient
                .GetItemsAsync(
                new DepthParameter(4),
                new EqualsFilter("system.type", "blog_entry"),
                new LanguageParameter(SiteContext.CurrentSiteCulture.ToLowerInvariant()),
                new EqualsFilter("system.language", SiteContext.CurrentSiteCulture.ToLowerInvariant()),
                new EqualsFilter("elements.seo_url", seoUrl)
                );

            var item = response.Items.FirstOrDefault();

            if (item == null)
            {
                return null;
            }

            var casted = item.CastTo<BlogEntry>();
            var mapped = Mapper.Map<BlogEntry, Blog>(casted);
            mapped.LastModified = item.System.LastModified;

            return mapped;
        }

        public async Task<Taxonomy> GetTaxonomyAsync()
        {
            var response = await KontentDeliveryClient.DeliveryClient.GetTaxonomiesAsync(
                new DepthParameter(1));

            var taxonomyGroup = response.Taxonomies;
            var result = new TaxonomyTypes();

            var personasTaxonomyGroup = taxonomyGroup.Where(tg => tg.System.Codename == "personas").FirstOrDefault();
            var personas = personasTaxonomyGroup.Terms.ToList();
            result.Personas = personas.Select(p => new Providers.Kontent.Models.TaxonomyTerm { Codename = p.Codename, Name = p.Name }).ToList();

            var segmentsTaxonomyGroup = taxonomyGroup.Where(tg => tg.System.Codename == "segments").FirstOrDefault();
            var segments = segmentsTaxonomyGroup.Terms.ToList();
            result.Segments = segments.Select(s => new Models.TaxonomyTerm { Codename = s.Codename, Name = s.Name }).ToList();

            return Mapper.Map<TaxonomyTypes, Taxonomy>(result);
        }
    }
}
