using System;
using System.ComponentModel.DataAnnotations;

namespace ShawContract.Providers.ProductBoard.Models
{
    public class ProductBoardItem : BaseModel
    {
        [Key]
        public Guid ID { get; set; }
        public string Notes { get; set; }
        [Required]
        public string StyleName { get; set; }
        [Required]
        public string StyleNumber { get; set; }
        [Required]
        public string ColorName { get; set; }
        [Required]
        public string ColorNumber { get; set; }
        [Required]
        public string ImageUrl { get; set; }

        public Guid ProductBoardID { get; set; }
        public virtual ProductBoard ProductBoard { get; set; }
    }
}