namespace ShawContract.Application.Models
{
    public class Blog : BaseModel
    {
        public Asset ImageMain { get; set; }

        public Asset ImageMedia { get; set; }

        public string LongDescription { get; set; }

        public string SeoFriendlyName { get; set; }

        public string ShortDescription { get; set; }

        public string SubTitle { get; set; }

        public string Title { get; set; }

        public string SeoUrl { get; set; }
    }
}