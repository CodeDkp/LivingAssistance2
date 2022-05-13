using System;
using System.Collections.Generic;

namespace LivingAssistance2.Models
{
    public partial class PatientDetail
    {
        public PatientDetail()
        {
            BookingDetails = new HashSet<BookingDetail>();
            Guardians = new HashSet<Guardian>();
        }

        public string Pid { get; set; } = null!;
        public string Fname { get; set; } = null!;
        public string? Mname { get; set; }
        public string Lname { get; set; } = null!;
        public string PAddress { get; set; } = null!;
        public string? TAddress { get; set; }
        public string? SelectedCg { get; set; }

        public virtual CareGiver? SelectedCgNavigation { get; set; }
        public virtual ICollection<BookingDetail> BookingDetails { get; set; }
        public virtual ICollection<Guardian> Guardians { get; set; }
    }
}
