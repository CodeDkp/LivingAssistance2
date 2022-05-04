namespace LivingAssistance2.Models
{
    public class ReportDetail
    {
        public string CareGive { get; set; } = null!;
        public string Patient { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string VerificationStatus { get; set; } = null!;
        public int Experience { get; set; }
        public string? Services { get; set; } = null!;
    }
}
