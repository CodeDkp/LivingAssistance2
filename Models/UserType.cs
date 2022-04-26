using System;
using System.Collections.Generic;

namespace LivingAssistance2.Models
{
    public partial class UserType
    {
        public UserType()
        {
            UserDetails = new HashSet<UserDetail>();
        }

        public string UserTypeId { get; set; } = null!;
        public string UserTypeName { get; set; } = null!;

        public virtual ICollection<UserDetail> UserDetails { get; set; }
    }
}
