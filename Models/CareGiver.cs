using System;
using System.Collections.Generic;

namespace LivingAssistance2.Models
{
    public partial class CareGiver
    {
        public CareGiver()
        {
            BookingDetail1s = new HashSet<BookingDetail1>();
            BookingDetails = new HashSet<BookingDetail>();
            PatientDetails = new HashSet<PatientDetail>();
        }

        public string Cid { get; set; } = null!;
        public string Fname { get; set; } = null!;
        public string? Mname { get; set; }
        public string Lname { get; set; } = null!;
        public string Uid { get; set; } = null!;
        public bool? IsIndividual { get; set; }
        public string? Address { get; set; }
        public string? Vfstatus { get; set; }
        public int? Experiance { get; set; }

        public virtual VerificationState? VfstatusNavigation { get; set; }
        public virtual ICollection<BookingDetail1> BookingDetail1s { get; set; }
        public virtual ICollection<BookingDetail> BookingDetails { get; set; }
        public virtual ICollection<PatientDetail> PatientDetails { get; set; }
    }
}
