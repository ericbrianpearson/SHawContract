using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShawContract.Providers.ProductBoard.Models
{
    public class ProductBoard : BaseModel
    {
        [Key]
        public Guid ID { get; set; }

        [Required, MaxLength(150)]
        public string BoardName { get; set; }

        public string Notes { get; set; }

        [Required]
        public string UserId { get; set; }

        public bool LoggedUserRequiredToAccess { get; set; }

        public virtual ICollection<ProductBoardItem> ProductBoardItems { get; set; }
        public virtual ICollection<Visitor> Visitors { get; set; }
    }
}