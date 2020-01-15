using System.Collections.Generic;

namespace ShawContract.Application.Models
{
    public class Taxonomy
    {
        public IEnumerable<TaxonomyTermDto> Personas { get; set; }
        public IEnumerable<TaxonomyTermDto> Segments { get; set; }
    }
}
