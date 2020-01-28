using System.Collections.Generic;
using ShawContract.Application.Models;

namespace ShawContract.Application.Contracts.Gateways
{
    public interface IPersonaGateway
    {
        IEnumerable<Persona> GetAllPersonas();
    }
}