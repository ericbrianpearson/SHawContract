using ShawContract.Application.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ShawContract.Models.Cart
{
    public class CartViewModel : IViewModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public IEnumerable<SelectListItem> QuantityDropdown => GetDropDownValues(); //minimun 1, maximum 10

        public string ErrorMessage { get; set; }

        public IEnumerable<CartItem> CartItems { get; set; }

        public static CartViewModel BuildCartViewModel(ShoppingCart shoppingCart, int quantity = 0)
        {
            return new CartViewModel
            {
                Title = shoppingCart.Title,
                Description = shoppingCart.Description,
                ErrorMessage = ValidateQuantity(quantity),
                CartItems = shoppingCart.CartItems
                .Select(item => new CartItem
                {
                    ItemId = item.CartItemID,
                    ItemName = item.CartItemName,
                    SampleTypes = item.SampleTypes.Select(t => new SelectListItem
                    {
                        Text = t,
                        Value = t
                    })
                })
            };
        }

        private IEnumerable<SelectListItem> GetDropDownValues()
        {
            for (int value = 1; value <= 10; value++)
            {
                yield return new SelectListItem() { Text = value.ToString(), Value = value.ToString() };
            }
        }

        private static string ValidateQuantity(int quantity)
        {
            return quantity > 30 ? "Maximum number of samples is 30." : string.Empty;
        }
    }
}