using ShawContract.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShawContract.Models.ProductBoards
{
    public class ProductBoardDetailsViewModel : IViewModel
    {
        public ProductBoard ProductBoard { get; set; }
    }
}