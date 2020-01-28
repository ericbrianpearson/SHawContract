using Newtonsoft.Json;
using System;

namespace ShawContract.Providers.ProductBoard.Models
{
    public class BaseModel
    {
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime ModifiedOn { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}