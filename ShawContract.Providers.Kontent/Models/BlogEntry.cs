using Newtonsoft.Json;
using System.Collections.Generic;
using Kentico.Kontent.Delivery;

namespace ShawContract.Providers.Kontent.Models
{
    public class BlogEntry
    {
        public const string Codename = "new_collection__mist";

        [JsonProperty("article_base_snippet__image__main")]
        public IEnumerable<WidenImage> ArticleBaseSnippetImageMedia { get; set; }
        [JsonProperty("article_base_snippet__long_description")]
        public string ArticleBaseSnippetLongdescription { get; set; }

        [JsonProperty("article_base_snippet__personas")]
        public IEnumerable<Kentico.Kontent.Delivery.TaxonomyTerm> ArticleBaseSnippetPersonas { get; set; }
        [JsonProperty("article_base_snippet__segments")]
        public IEnumerable<Kentico.Kontent.Delivery.TaxonomyTerm> ArticleBaseSnippetSegments { get; set; }

        public string ArticleBaseSnippetSeoFriendlyName { get; set; }

        public string ArticleBaseSnippetShortDescription { get; set; }


        public string ArticleBaseSnippetSubTitle { get; set; }

        public string ArticleBaseSnippetTitle { get; set; }
        [JsonProperty("seo_url")]
        public string ArticleBaseSnippetSeoUrl { get; set; }

        [JsonProperty("cta")]
        public IEnumerable<Cta> PlaceholderCta { get; set; }

        public BlogEntry()
        { }
    }
}