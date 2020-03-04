using ShawContract.Application.Contracts.Infrastructure;
using ShawContract.Application.Models;

namespace ShawContract.Models.Cart
{
    public class CartViewModel : IViewModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public int ItemsCount { get; set; }

        public static CartViewModel BuildCartViewModel(ShoppingCartPage cartPage) //get title and description
        {
            return new CartViewModel
            {
                Title = cartPage.Title,
                Description = cartPage.Description,
                ItemsCount = cartPage.CartItemsCount
            };
        }
    }
}