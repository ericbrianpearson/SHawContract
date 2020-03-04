using System.Collections.Generic;
using System.Web.Mvc;
using ShawContract.Models.Personalization;

namespace ShawContract.Models.Checkout
{
    public class CheckoutViewModel : IViewModel
    {
        public IList<SelectListItem> Addresses { get; set; } //get from user settings

        public IEnumerable<AccountManager> AccountManagers { get; set; } //get from salesforce

        public string Title { get; set; }

        public string Description { get; set; }

        public static CheckoutViewModel BuildCheckoutViewModel(IList<Address> shippingAddresses, string title, string description) //add accountmanagers here as a parameter
        {
            var model = new CheckoutViewModel();
            model.Addresses = GetShippingAddresses(shippingAddresses);
            model.AccountManagers = new List<AccountManager>()
            {
                    new AccountManager()
                    {
                        AccountNumber = 1,
                        Name = "Kevin Bettis",
                        Place = "Metro Atlanta",
                        EmailAddress = "kevin.bettis@shawcontract.com",
                        PhoneNumber = "(770) 547-12345"
                    },
                    new AccountManager()
                    {
                        AccountNumber = 2,
                        Name = "Kevin Bettis",
                        Place = "Metro Atlanta",
                        EmailAddress = "kevin.bettis@shawcontract.com",
                        PhoneNumber = "(770) 547-09876"
                    }
            };
            model.Title = title;
            model.Description = description;

            return model;
        }

        private static List<SelectListItem> GetShippingAddresses(IList<Address> shippingAddresses)
        {
            var addresses = new List<SelectListItem>();

            if (shippingAddresses != null && shippingAddresses.Count > 0)
            {
                foreach (var address in shippingAddresses)
                {
                    addresses.Add(new SelectListItem()
                    {
                        Text = address.StreetLine1,
                        Value = address.StreetLine1
                    });
                }
            }
            else
            {
                addresses = new List<SelectListItem>
                {
                    new SelectListItem()
                    {
                        Text = "address",
                        Value = "address"
                    },
                    new SelectListItem()
                    {
                        Text = "address 2",
                        Value = "address 2"
                    }
                };
            }

            return addresses;
        }
    }

    public class AccountManager //take from salesforce
    {
        public int AccountNumber { get; set; }
        public string Name { get; set; }
        public string Place { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
    }
}