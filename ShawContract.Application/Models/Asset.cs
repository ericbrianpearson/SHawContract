namespace ShawContract.Application.Models
{
    public class Asset : BaseModel
    {
        public string Name { get; }

        public string Description { get; }

        public string Type { get; }

        public int Size { get; }

        public string Url { get; }

        public int Width { get; set; }

        public int Height { get; set; }
    }
}