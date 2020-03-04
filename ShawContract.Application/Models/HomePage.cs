using System.Collections.Generic;

namespace ShawContract.Application.Models
{
    public class HomePage
    {
        public string Title { get; set; }
        public int DocumentID { get; set; }

        public List<CarouselSection> CarouselSections { get; set; }
    }
}
