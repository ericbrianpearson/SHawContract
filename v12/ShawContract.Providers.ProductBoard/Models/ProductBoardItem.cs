using System;
using System.ComponentModel.DataAnnotations;

namespace ShawContract.Providers.ProductBoard.Models
{
    public class ProductBoardItem : BaseModel
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        public string Style { get; set; }

        [Required]
        public string Color { get; set; }

        public string Notes { get; set; }

        public Guid ProductBoardID { get; set; }
        public virtual ProductBoard ProductBoard { get; set; }
    }
}