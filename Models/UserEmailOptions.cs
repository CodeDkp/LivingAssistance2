using System.ComponentModel.DataAnnotations;

namespace LivingAssistance2.Models
{
    public class UserEmailOptions
    {   
        [Required]
        public List<string> ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

    }
}
