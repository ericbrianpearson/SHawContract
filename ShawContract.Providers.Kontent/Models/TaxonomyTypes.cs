using System.Collections.Generic;

namespace ShawContract.Providers.Kontent.Models
{
    public class TaxonomyTypes
    {
        public IEnumerable<TaxonomyTerm> Personas { get; set; }
        public IEnumerable<TaxonomyTerm> Segments { get; set; }
    }
}
