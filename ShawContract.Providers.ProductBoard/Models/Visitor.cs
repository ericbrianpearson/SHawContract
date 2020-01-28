using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
