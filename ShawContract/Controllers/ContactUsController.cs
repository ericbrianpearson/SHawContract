using System.Web.Mvc;
using CMS.EventLog;
using ShawContract.Application.Contracts.Services;
using ShawContract.Application.Models;
using ShawContract.Models.ContactUs;

namespace ShawContract.Controllers
{
    public class ContactUsController : BaseController
    {
        private IContactUsService DropDownService { get; }
        private IContactService ContactService { get; }
        private IMailingService MailingService { get; }

        public ContactUsController(IMasterPageService masterPageService, IContactUsService dropDownService, IContactService contactService, IMailingService mailingService) : base(masterPageService)
        {
            this.DropDownService = dropDownService;
            this.ContactService = contactService;
            this.MailingService = mailingService;
        }

        // GET: ContactUs
        public ActionResult Index(string nodeAlias)
        {
            var model = GetPageModelWithProperties(nodeAlias);
            return View(model);
        }


        public ActionResult SendMail(ContactUsEmail email, string alias)
        {
            MailingService.SendEmail(email);
            var model = this.GetPageModelWithProperties(alias);
            model.Data.Mail = email;
            return View("Index", model);
        }


        private Models.PageViewModel<ContactViewModel> GetPageModelWithProperties(string nodeAlias)
        {
            var contactPageId = ContactService.GetContactPage(nodeAlias).DocumentID;
            var menus = DropDownService.GetDropDowns(nodeAlias);

            var model = GetPageViewModel(new ContactViewModel() { Menus = menus }, nodeAlias);
            return model;
        }
    }
}