namespace ShawContract.Application.Models
{
    public class GenericContentPage : BaseModel
    {
        public int DocumentId { get; set; }
        public string Title { get; set; }
        public string CustomCSSClass { get; set; }
    }
}