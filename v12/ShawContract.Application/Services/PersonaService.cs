using System.Collections.Generic;
using ShawContract.Application.Contracts.Gateways;
using ShawContract.Application.Contracts.Services;
using ShawContract.Application.Models;

namespace ShawContract.Application.Services
{
    public class PersonaService : IPersonaService
    {
        private IPersonaGateway PersonaGateway { get; }

        public PersonaService(IPersonaGateway personaGateway)
        {
            this.PersonaGateway = personaGateway;
        }

        public IEnumerable<Persona> GetAllPersonas()
        {
            return this.PersonaGateway.GetAllPersonas();
        }
    }
}