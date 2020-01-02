using System.Web.Mvc;
using ShawContract.Application.Contracts.Infrastructure;
using Twilio.AspNet.Mvc;
using Twilio.TwiML;

namespace ShawContract.Controllers
{
    public class TwilioIntegrationController : TwilioController
    {
        public ITwilioClientService TwilioClientService { get; set; }

        public TwilioIntegrationController(ITwilioClientService twilioClientService)
        {
            TwilioClientService = twilioClientService;
        }

        // GET: Twilio
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CallCustomer(string phoneNumber)
        {
            TwilioClientService.Call(phoneNumber);

            return new TwiMLResult();
        }

        [HttpPost]
        public ActionResult PlayMessage()
        {
            var response = TwilioClientService.ConstructVoiceResponse();

            return TwiML(response as VoiceResponse);
        }
    }
}