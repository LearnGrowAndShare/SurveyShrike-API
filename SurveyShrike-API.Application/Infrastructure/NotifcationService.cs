using SurveyShrike_API.Application.Interfaces;
using System.Threading.Tasks;

/// <summary>
/// @author Ankit
/// @date - 10/14/2019 5:44:03 PM 
/// </summary>
namespace SurveyShrike_API.Application.Infrastructure
{
    /// <summary>
    /// Notification service provides the notification to the event.
    /// </summary>
    public class NotificationService : INotificationService
    {
        /// <summary>
        /// send the notifcation.
        /// </summary>
        /// <param name="message"><seealso cref="Message"> Message </seealso> object to be sent to event listing to the notifcation.</param>
        /// <returns></returns>
        public Task SendAsync(Message message)
        {
            return Task.CompletedTask;
        }
    }
}
