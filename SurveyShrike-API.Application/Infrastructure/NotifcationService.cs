using SurveyShrike_API.Application.Interfaces;
using System.Threading.Tasks;

/// <summary>
/// @author Ankit
/// @date - 10/14/2019 5:44:03 PM 
/// </summary>
namespace SurveyShrike_API.Application.Infrastructure
{
    public class NotificationService : INotificationService
    {
        public Task SendAsync(Message message)
        {
            return Task.CompletedTask;
        }
    }
}
