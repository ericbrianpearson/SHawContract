using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Kentico.Membership;
using Microsoft.AspNet.Identity.Owin;
using Newtonsoft.Json;
using ShawContract.Application.Contracts.Services;
using ShawContract.Models.Personalization;
using ShawContract.Utils;

namespace ShawContract.Controllers
{
    public class UserSettingsController : BaseController
    {
        public UserSettingsController(IMasterPageService masterPageService)
            : base(masterPageService)
        { }
        public ActionResult EditAddress(UserSettingsViewModel userSettings)
        {
            return PartialView("~/Views/Shared/_ShippingAddressModal.cshtml", userSettings);
        }

        public ActionResult AddAddress(UserSettingsViewModel userSettings)
        {
            userSettings.AddressToEdit = new Address();
            return PartialView("~/Views/Shared/_ShippingAddressModal.cshtml", userSettings);
        }
      
        // GET: UserSettings
        public async Task<ActionResult> Index()
        {
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("RequestSignIn", "Account", new { provider = "", returnUrl = Url.Action("Index", "UserSettings") });
            }

            KenticoSignInManager<ExtendedUser> kenticoSignInManager = HttpContext.GetOwinContext().Get<KenticoSignInManager<ExtendedUser>>();
            ExtendedUser user = await kenticoSignInManager.UserManager.FindByEmailAsync(this.User.Identity.Name);

            UserSettingsViewModel settingModel = PopulateViewModel(user);

            var model = GetPageViewModel(settingModel, null);

            return View(model);
        }

        public async Task<ActionResult> RemoveAddress(string line1, string line2)
        {
            KenticoSignInManager<ExtendedUser> kenticoSignInManager = HttpContext.GetOwinContext().Get<KenticoSignInManager<ExtendedUser>>();
            ExtendedUser user = await kenticoSignInManager.UserManager.FindByEmailAsync(this.User.Identity.Name);

            IList<Address> addresses = user.ShippingAddressesList;
            for (int i = addresses.Count - 1; i >= 0; i--)
            {
                if (addresses[i].StreetLine1 == line1 && addresses[i].StreetLine2 == line2)
                {
                    addresses.RemoveAt(i);
                    break;
                }
            }

            user.ShippingAddressesList = addresses;
            await kenticoSignInManager.UserManager.UpdateAsync(user);

            return this.RedirectToAction("Index");
        }

        public async Task<ActionResult> SaveCommunicationInfo(Models.PageViewModel<UserSettingsViewModel> settingModel)
        {
            if (string.IsNullOrEmpty(settingModel.Data.Language))
            {
                throw new ArgumentNullException("Language is null or empty");
            }

            KenticoSignInManager<ExtendedUser> kenticoSignInManager = HttpContext.GetOwinContext().Get<KenticoSignInManager<ExtendedUser>>();
            ExtendedUser user = await kenticoSignInManager.UserManager.FindByEmailAsync(this.User.Identity.Name);

            user.Language = settingModel.Data.Language;
            user.Segments = JsonConvert.SerializeObject(settingModel.Data.Segments);

            await kenticoSignInManager.UserManager.UpdateAsync(user);

            return this.RedirectToAction("Index");
        }

        public async Task<ActionResult> SaveCompanyInfo(Models.PageViewModel<UserSettingsViewModel> settingModel)
        {
            if (string.IsNullOrEmpty(settingModel.Data.CompanyName) ||
                string.IsNullOrEmpty(settingModel.Data.JobTitle) ||
                string.IsNullOrEmpty(settingModel.Data.Industry))
            {
                throw new ArgumentNullException("CompanyName, JobTitle or Industry is null or empty");
            }

            KenticoSignInManager<ExtendedUser> kenticoSignInManager = HttpContext.GetOwinContext().Get<KenticoSignInManager<ExtendedUser>>();
            ExtendedUser user = await kenticoSignInManager.UserManager.FindByEmailAsync(this.User.Identity.Name);

            user.CompanyName = settingModel.Data.CompanyName;
            user.JobTitle = settingModel.Data.JobTitle;
            user.Industry = settingModel.Data.Industry;
            user.WorkPhone = settingModel.Data.WorkPhone;
            user.WorkPhoneExtension = settingModel.Data.WorkPhoneExtension;

            await kenticoSignInManager.UserManager.UpdateAsync(user);

            return this.RedirectToAction("Index");
        }

        public async Task<ActionResult> SavePersonalInfo(Models.PageViewModel<UserSettingsViewModel> settingModel)
        {
            if (string.IsNullOrEmpty(settingModel.Data.FirstName) || 
                string.IsNullOrEmpty(settingModel.Data.LastName) || 
                string.IsNullOrEmpty(settingModel.Data.CellPhone))
            {
                throw new ArgumentNullException("FirstName, LastName or CellPhone is null or empty");
            }

            KenticoSignInManager<ExtendedUser> kenticoSignInManager = HttpContext.GetOwinContext().Get<KenticoSignInManager<ExtendedUser>>();
            ExtendedUser user = await kenticoSignInManager.UserManager.FindByEmailAsync(this.User.Identity.Name);

            user.Title = settingModel.Data.Title;
            user.FirstName = settingModel.Data.FirstName;
            user.LastName = settingModel.Data.LastName;
            user.CellPhone = settingModel.Data.CellPhone;

            await kenticoSignInManager.UserManager.UpdateAsync(user);

            return this.RedirectToAction("Index");
        }

        public async Task<ActionResult> SaveShippingInfo(UserSettingsViewModel userSettings)
        {
            var address = userSettings.AddressToEdit;
            KenticoSignInManager<ExtendedUser> kenticoSignInManager = HttpContext.GetOwinContext().Get<KenticoSignInManager<ExtendedUser>>();
            ExtendedUser user = await kenticoSignInManager.UserManager.FindByEmailAsync(this.User.Identity.Name);
            List<Address> addresses = user.ShippingAddressesList.ToList();

            var existingAddress = addresses.FirstOrDefault(ad => ad.Id == address.Id);
            if (existingAddress != null)
            {
                var index = addresses.IndexOf(existingAddress);
                addresses[index] = address;
            }
            else
            {
                address.Id = Guid.NewGuid();
                addresses.Add(address);
            }

            if (addresses.Count == 1)
            {
                // if first address to add, make it default
                addresses[0].IsDefault = true;
            }
            user.FirstName = userSettings.FirstName;
            user.LastName = userSettings.LastName;
            user.CompanyName = userSettings.CompanyName;
            user.ShippingAddressesList = addresses;
            await kenticoSignInManager.UserManager.UpdateAsync(user);

            return this.RedirectToAction("Index");
        }

        public async Task<ActionResult> SetDefaultAddress(string line1, string line2)
        {
            KenticoSignInManager<ExtendedUser> kenticoSignInManager = HttpContext.GetOwinContext().Get<KenticoSignInManager<ExtendedUser>>();
            ExtendedUser user = await kenticoSignInManager.UserManager.FindByEmailAsync(this.User.Identity.Name);

            IList<Address> addresses = user.ShippingAddressesList;
            for (int i = addresses.Count - 1; i >= 0; i--)
            {
                if (addresses[i].StreetLine1 == line1 && addresses[i].StreetLine2 == line2)
                {
                    addresses[i].IsDefault = true;
                }
                else
                {
                    addresses[i].IsDefault = false;
                }
            }

            user.ShippingAddressesList = addresses;
            await kenticoSignInManager.UserManager.UpdateAsync(user);

            return this.RedirectToAction("Index");
        }

      
        private static UserSettingsViewModel PopulateViewModel(ExtendedUser user)
        {
            UserSettingsViewModel settingModel = new UserSettingsViewModel();
            settingModel.Title = user.Title;
            settingModel.FirstName = user.FirstName;
            settingModel.LastName = user.LastName;
            settingModel.CompanyName = user.CompanyName;
            settingModel.Email = user.Email;
            settingModel.JobTitle = user.JobTitle;
            settingModel.WorkPhone = user.WorkPhone;
            settingModel.WorkPhoneExtension = user.WorkPhoneExtension;
            settingModel.Language = user.Language;
            settingModel.Industry = user.Industry;
            if (string.IsNullOrEmpty(user.Segments))
            {
                settingModel.Segments = new List<string>();
            }
            else
            {
                settingModel.Segments = JsonConvert.DeserializeObject<List<string>>(user.Segments);
            }
            if (string.IsNullOrEmpty(user.ShippingAddresses))
            {
                settingModel.ShippingAddresses = new List<Address>();
            }
            else
            {
                settingModel.ShippingAddresses = JsonConvert.DeserializeObject<List<Address>>(user.ShippingAddresses);
                settingModel.ShippingAddresses = settingModel.ShippingAddresses.OrderByDescending(x => x.IsDefault).ToList();
            }
            settingModel.CellPhone = user.CellPhone;
            return settingModel;
        }
    }
}
