using System.ComponentModel.DataAnnotations;

namespace LivingAssistance2.Models
{
    public class Report
    {
        [Required]
        public Searchtype Usertype { get; set; }
        [Required]
        public String Name { get; set; } = null;
        [Required]
        public string? Address { get; set; } = null;
        [Required]
        public DateTime dt1 { get; set; }
        [Required]
        public DateTime dt2 { get; set; }
    }
    public enum Searchtype
    {
        Patient,
        CareGiver
    }
}


