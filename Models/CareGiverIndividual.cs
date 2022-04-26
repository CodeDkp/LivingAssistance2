using System;
using System.Collections.Generic;

namespace LivingAssistance2.Models
{
    public partial class CareGiverIndividual
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? Age { get; set; }
        public string? Gender { get; set; }
        public string UserId { get; set; } = null!;
        public string? Password { get; set; }
        public string? Contact { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Qualification { get; set; }
        public string? Specialization { get; set; }
        public string? Experience { get; set; }
        public string? Servicecity { get; set; }
    }
}
