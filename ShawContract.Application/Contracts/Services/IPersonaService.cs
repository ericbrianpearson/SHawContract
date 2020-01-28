using System.Collections.Generic;
using ShawContract.Application.Models;

namespace ShawContract.Application.Contracts.Services
{
    public interface IPersonaService
    {
        IEnumerable<Persona> GetAllPersonas();
    }
}