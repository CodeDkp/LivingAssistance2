using System;
using System.Collections.Generic;

namespace LivingAssistance2.Models
{
    public partial class BookingDetail
    {
        public string BookingReferenceId { get; set; } = null!;
        public string? PatientId { get; set; }
        public string? CareGiverId { get; set; }
        public DateTime BookingDate { get; set; }
        public TimeSpan BookingTime { get; set; }
        public string Address { get; set; } = null!;
        public string ServicesReq { get; set; } = null!;
        public decimal TotalCharges { get; set; }

        public virtual CareGiver? CareGiver { get; set; }
        public virtual PatientDetail? Patient { get; set; }
    }
}
