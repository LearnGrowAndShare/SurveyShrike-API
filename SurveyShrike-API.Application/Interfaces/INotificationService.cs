using System.Threading.Tasks;

namespace SurveyShrike_API.Application.Interfaces
{
    /// <summary>
    /// Notifcation service interface.
    /// </summary>
    public interface INotificationService
    {
        /// <summary>
        /// Send the notification..
        /// </summary>
        /// <param name="message">Message to be sent.</param>
        /// <returns>Task </returns>
        Task SendAsync(Message message);
    }
}