using System;
using System.ComponentModel.DataAnnotations;

namespace ShawContract.Providers.ProductBoard.Models
{
    public class Visitor
    {
        [Key]
        public Guid Id { get; set; }

        public string Email { get; set; }
        public DateTime DateVisited { get; set; }

        public Guid ProductBoardID { get; set; }
        public virtual ProductBoard ProductBoard { get; set; }
    }
}
