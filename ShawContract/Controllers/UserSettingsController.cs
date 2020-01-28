using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Kentico.Membership;
using Microsoft.AspNet.Identity.Owin;
using Newtonsoft.Json;
using ShawContract.Application.Contracts.Services;
using ShawContract.Models.Personalization;

namespace ShawContract.Controllers
{
    [Authorize]
    public class UserSettingsController : BaseController
    {
        public UserSettingsController(IMasterPageService masterPageService)
            : base(masterPageService)
        { }

        // GET: UserSettings
        public async Task<ActionResult> Index()
        {
            KenticoSignInManager<ExtendedUser> kenticoSignInManager = HttpContext.GetOwinContext().Get<KenticoSignInManager<ExtendedUser>>();
            ExtendedUser user = await kenticoSignInManager.UserManager.FindByEmailAsync(this.User.Identity.Name);

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
            if (string.IsNullOrEmpty(user.Segments))
            {
                settingModel.Segments = new List<string>();
            }
            else
            {
                settingModel.Segments = JsonConvert.DeserializeObject<List<string>>(user.Segments);
            }
            settingModel.CellPhone = user.CellPhone;

            var model = GetPageViewModel(settingModel, null);

            return View(model);
        }

        public async Task<ActionResult> SaveCommunicationInfo(Models.PageViewModel<UserSettingsViewModel> settingModel)
        {
            KenticoSignInManager<ExtendedUser> kenticoSignInManager = HttpContext.GetOwinContext().Get<KenticoSignInManager<ExtendedUser>>();
            ExtendedUser user = await kenticoSignInManager.UserManager.FindByEmailAsync(this.User.Identity.Name);

            user.Language = settingModel.Data.Language;
            user.Segments = JsonConvert.SerializeObject(settingModel.Data.Segments);

            await kenticoSignInManager.UserManager.UpdateAsync(user);

            return this.RedirectToAction("Index");
        }

        public async Task<ActionResult> SaveCompanyInfo(Models.PageViewModel<UserSettingsViewModel> settingModel)
        {
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
            KenticoSignInManager<ExtendedUser> kenticoSignInManager = HttpContext.GetOwinContext().Get<KenticoSignInManager<ExtendedUser>>();
            ExtendedUser user = await kenticoSignInManager.UserManager.FindByEmailAsync(this.User.Identity.Name);

            user.Title = settingModel.Data.Title;
            user.FirstName = settingModel.Data.FirstName;
            user.LastName = settingModel.Data.LastName;
            user.CellPhone = settingModel.Data.CellPhone;

            await kenticoSignInManager.UserManager.UpdateAsync(user);

            return this.RedirectToAction("Index");
        }
    }
}
