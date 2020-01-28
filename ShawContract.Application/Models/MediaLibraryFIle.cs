using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShawContract.Application.Models
{
    public class MediaLibraryFile : BaseModel
    {
        public Guid Guid { get; set; }
        public string Title { get; set; }
        public string DirectUrl { get; set; }
        public string PermanentUrl { get; set; }
        public string Extension { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}