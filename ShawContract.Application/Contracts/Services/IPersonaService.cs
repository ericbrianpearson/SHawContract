using ShawContract.Application.Models;
using System.Collections.Generic;

namespace ShawContract.Application.Contracts.Services
{
    public interface IPersonaService
    {
        IEnumerable<Persona> GetAllPersonas();
    }
}