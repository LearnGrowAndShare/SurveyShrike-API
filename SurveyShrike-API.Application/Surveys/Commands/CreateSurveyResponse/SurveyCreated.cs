using MediatR;
using SurveyShrike_API.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace SurveyShrike_API.Application.Surveys.Commands.CreateSurveyResponse
{
    /// <summary>
    /// survey created event
    /// </summary>
    public class SurveyCreated : INotification
    {
        /// <summary>
        /// SurveyCreatedHandler
        /// </summary>
        public class SurveyCreatedHandler : INotificationHandler<SurveyCreated>
        {    /// <summary>
             /// Notification service.
             /// </summary>
            private readonly INotificationService _notification;

            /// <summary>
            /// constructor for SurveyCreatedHandler
            /// </summary>
            /// <param name="notification"></param>
            public SurveyCreatedHandler(INotificationService notification)
            {
                _notification = notification;
            }

            /// <summary>
            /// Handle called by the MediaR to inform the subscriber about the events.
            /// </summary>
            /// <param name="notification">Notifcation message</param>
            /// <param name="cancellationToken">Cancellation token</param>
            /// <returns>Task</returns>
            public async Task Handle(SurveyCreated notification, CancellationToken cancellationToken)
            {
                await _notification.SendAsync(new Message());
            }
        }
    }
}