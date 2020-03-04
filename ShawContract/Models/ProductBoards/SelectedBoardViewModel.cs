using ShawContract.Application.Models;
using System.Web;

namespace ShawContract.Models.ProductBoards
{
    public class SelectedBoardViewModel
    {
        public ProductBoard Board { get; set; }
        public string BoardUrl { get; set; }
        public string SiteUrl => HttpContext.Current.Request.Url.GetLeftPart(System.UriPartial.Authority);
    }
}