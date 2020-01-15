using System.Collections.Generic;

namespace ShawContract.Application.Models
{
    public class BlogPreview
    {
        public ImageDto Image { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string ShortDescription { get; set; }
        public string SeoUrl { get; set; }
        public IEnumerable<TaxonomyTermDto> ArticleBaseSnippetPersonas { get; set; }
        public IEnumerable<TaxonomyTermDto> ArticleBaseSnippetSegments { get; set; }
        public CtaDto Cta { get; set; }

    }
}
