using System;

namespace ShawContract.Application.Models
{
    public class Persona
    {
        public Guid PersonaGUID { get; set; }
        public bool PersonaEnabled { get; set; }
        public string PersonaDescription { get; set; }
        public string PersonaDisplayName { get; set; }
        public string PersonaName { get; set; }
    }
}