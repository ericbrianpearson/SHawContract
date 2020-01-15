using System;
using System.Collections.Generic;

namespace ShawContract.Application.Models
{
    public class Blog : BaseModel
    {
        public ImageDto MainImage { get; set; }
        public string LongDescription { get; set; }

        public string SeoFriendlyName { get; set; }

        public string ShortDescription { get; set; }

        public string SubTitle { get; set; }

        public string Title { get; set; }

        public string SeoUrl { get; set; }
        public CtaDto PlaceHolderCTA { get; set; }
        public DateTime LastModified { get; set; }
        public IEnumerable<TaxonomyTermDto> ArticleBaseSnippetPersonas { get; set; }
        public IEnumerable<TaxonomyTermDto> ArticleBaseSnippetSegments { get; set; }


    }
}