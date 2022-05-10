using System;
using System.Collections.Generic;

namespace LivingAssistance2.Models
{
    public partial class Patient
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
        public string? GuardianContact { get; set; }
        public string? City { get; set; }
        public string? Serviceneeded { get; set; }
    }
}
