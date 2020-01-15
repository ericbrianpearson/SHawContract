namespace ShawContract.Application.Models
{
    public class CtaDto : BaseModel
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string ButtonText { get; set; }
        public string ButtonUrl { get; set; }
    }
}
