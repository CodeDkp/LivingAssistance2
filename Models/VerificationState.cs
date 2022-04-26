using System;
using System.Collections.Generic;

namespace LivingAssistance2.Models
{
    public partial class VerificationState
    {
        public VerificationState()
        {
            CareGivers = new HashSet<CareGiver>();
        }

        public string VerificationId { get; set; } = null!;
        public string State { get; set; } = null!;

        public virtual ICollection<CareGiver> CareGivers { get; set; }
    }
}
