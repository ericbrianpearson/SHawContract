using System.Collections.Generic;
using AutoMapper;
using CMS.Personas;
using ShawContract.Application.Contracts.Gateways;
using ShawContract.Application.Models;

namespace ShawContract.Providers.Kentico
{
    public class PersonaGateway : IPersonaGateway
    {
        private IMapper Mapper { get; }

        public PersonaGateway(IMapper mapper)
        {
            this.Mapper = mapper;
        }

        public IEnumerable<Persona> GetAllPersonas()
        {
            var personas = PersonaInfoProvider.GetPersonas();
            return this.Mapper.Map<IEnumerable<PersonaInfo>, IEnumerable<Persona>>(personas);
        }
    }
}