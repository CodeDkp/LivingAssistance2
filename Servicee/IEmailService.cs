using LivingAssistance2.Models;

namespace LivingAssistance2.Servicee
{
    public interface IEmailService
    {
        Task SendTestEmail(UserEmailOptions userEmailOptions);
    }
}