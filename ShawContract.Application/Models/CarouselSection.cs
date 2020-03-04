using System.Collections.Generic;

namespace ShawContract.Application.Models
{
    public class CarouselSection
    {
        public string Title { get; set; }
        public bool IsLarge { get; set; }
        public List<CarouselItem> CarouselItems { get; set; }
    }
}
