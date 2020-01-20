using Kentico.PageBuilder.Web.Mvc.Personalization;
using ShawContract.Application.Contracts.Services;
using ShawContract.Models.Personalization.ConditionTypes.IsInPersona;
using ShawContract.Personalization;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ShawContract.Controllers.Personalization
{
    public class IsInPersonaController : ConditionTypeController<IsInPersonaConditionType>
    {
        private IPersonaService PersonaService { get; }

        public IsInPersonaController(IPersonaService personaService)
        {
            this.PersonaService = personaService;
        }

        [HttpPost]
        public ActionResult Index()
        {
            var conditionTypeParameters = GetParameters();
            var viewModel = new IsInPersonaViewModel
            {
                PersonaCodeName = conditionTypeParameters.PersonaName,
                AllPersonas = GetAllPersonas(conditionTypeParameters.PersonaName)
            };
            return PartialView("Personalization/_IsInPersonaConfiguration", viewModel);
        }

        [HttpPost]
        public ActionResult Validate(IsInPersonaViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.AllPersonas = GetAllPersonas();
                return PartialView("Personalization/_IsInPersonaConfiguration", viewModel);
            }

            var parameters = new IsInPersonaConditionType
            {
                PersonaName = viewModel.PersonaCodeName
            };

            return Json(parameters);
        }

        private List<IsInPersonaListItemViewModel> GetAllPersonas(string personaName = "")
        {
            var allPersonas = this.PersonaService.GetAllPersonas().Select(persona => new IsInPersonaListItemViewModel
            {
                CodeName = persona.PersonaName,
                DisplayName = persona.PersonaDisplayName,
                // ImagePath = mPictureCreator.CreatePersonaPictureUrl(persona, 50),
                Selected = persona.PersonaName == personaName
            }).ToList();

            if (allPersonas.Count > 0 && !allPersonas.Exists(x => x.Selected))
            {
                allPersonas.First().Selected = true;
            }

            return allPersonas;
        }
    }
}