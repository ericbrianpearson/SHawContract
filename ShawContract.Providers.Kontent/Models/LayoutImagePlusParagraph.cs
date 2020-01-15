using Kentico.Kontent.Delivery;
using System.Collections.Generic;

namespace ShawContract.Providers.Kontent.Models
{
    public partial class LayoutImagePlusParagraph
        {
            public string Paragraph { get; set; }
            public IEnumerable<WidenImage> Image { get; set; }
            public IEnumerable<MultipleChoiceOption> ImageLocation { get; set; }
        }
    
}
