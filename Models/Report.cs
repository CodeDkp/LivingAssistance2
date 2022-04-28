using System.ComponentModel.DataAnnotations;

namespace LivingAssistance2.Models
{
    public class Report
    {
        [Required]
        public Searching Searchtype { get; set; }
        [Required]
        public String SearchData { get; set; }
    }
    public enum Searching
    {
        Patient,
        CareGiver
    }
}


