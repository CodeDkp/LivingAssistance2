using System;
using System.Collections.Generic;

namespace LivingAssistance2.Models
{
    public partial class Guardian
    {
        public string Gid { get; set; } = null!;
        public string Fname { get; set; } = null!;
        public string? Mname { get; set; }
        public string Lname { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string? PatientId { get; set; }
        public string RelationWithPatient { get; set; } = null!;

        public virtual PatientDetail? Patient { get; set; }
    }
}
