using System.Threading.Tasks;

namespace SurveyShrike_API.Application.Interfaces
{
    public interface INotificationService
    {
        Task SendAsync(Message message);
    }
}