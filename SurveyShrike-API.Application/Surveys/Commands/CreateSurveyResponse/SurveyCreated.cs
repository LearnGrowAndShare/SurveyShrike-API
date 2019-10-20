using MediatR;
using SurveyShrike_API.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace SurveyShrike_API.Application.Surveys.Commands.CreateSurveyResponse
{
    public class SurveyCreated : INotification
    {

        public class SurveyCreatedHandler : INotificationHandler<SurveyCreated>
        {
            private readonly INotificationService _notification;

            public SurveyCreatedHandler(INotificationService notification)
            {
                _notification = notification;
            }

            public async Task Handle(SurveyCreated notification, CancellationToken cancellationToken)
            {
                await _notification.SendAsync(new Message());
            }
        }
    }
}