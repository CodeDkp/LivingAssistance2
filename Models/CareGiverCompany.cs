using System;
using System.Collections.Generic;

namespace LivingAssistance2.Models
{
    public partial class CareGiverCompany
    {
        public string? CompanyName { get; set; }
        public string? RegistrationNo { get; set; }
        public string UserId { get; set; } = null!;
        public string? Password { get; set; }
        public string? ContactNumber { get; set; }
        public string? Email { get; set; }
        public string? NumberOfProfessional { get; set; }
        public string? MinQualificationOfStaffs { get; set; }
        public string? Experiance { get; set; }
        public string? RecoginationAndAchievements { get; set; }
        public int? RatingsOfTheCompany { get; set; }
        public string? ServiceCity { get; set; }
    }
}
