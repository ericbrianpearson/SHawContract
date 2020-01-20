using CMS.ContactManagement;
using CMS.Personas;
using Kentico.PageBuilder.Web.Mvc.Personalization;
using Newtonsoft.Json;
using ShawContract.Controllers.Personalization;
using ShawContract.Personalization;
using System;

[assembly: RegisterPersonalizationConditionType("ShawContract.Personalization.IsInPersona",
    typeof(IsInPersonaConditionType),
    "IsInPersona",
    ControllerType = typeof(IsInPersonaController),
    Description = "Is in Persona",
    Hint = "Select persona",
    IconClass = "icon-app-personas")]

namespace ShawContract.Personalization
{
    public class IsInPersonaConditionType : ConditionType
    {
        public string PersonaName { get; set; }

        /// <summary>
        /// Automatically populated variant name.
        /// </summary>
        public override string VariantName
        {
            get
            {
                return Persona?.PersonaDisplayName;
            }
            set
            {
                // No need to set automatically generated variant name
            }
        }

        private readonly Lazy<PersonaInfo> mPersona;

        [JsonIgnore]
        private PersonaInfo Persona => mPersona.Value;

        /// <summary>
        /// Creates an empty instance of <see cref="IsInPersonaConditionType"/> class.
        /// </summary>
        public IsInPersonaConditionType()
        {
            mPersona = new Lazy<PersonaInfo>(() => PersonaInfoProvider.GetPersonaInfoByCodeName(PersonaName));
        }

        /// <summary>
        /// Evaluate condition type.
        /// </summary>
        /// <returns>Returns <c>true</c> if implemented condition is met.</returns>
        public override bool Evaluate()
        {
            if (Persona == null)
            {
                return false;
            }

            var contact = ContactManagementContext.GetCurrentContact(false);

            return contact?.ContactPersonaID == Persona.PersonaID;
        }
    }
}