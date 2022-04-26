using System;
using System.Collections.Generic;

namespace LivingAssistance2.Models
{
    public partial class UserDetail
    {
        public string Fname { get; set; } = null!;
        public string? Mname { get; set; }
        public string Lname { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? UserTypeId { get; set; }

        public virtual UserType? UserType { get; set; }
    }
}
