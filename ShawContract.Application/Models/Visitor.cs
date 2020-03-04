using System;

namespace ShawContract.Application.Models
{
    public class Visitor
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public DateTime DateVisited { get; set; }
    }
}
