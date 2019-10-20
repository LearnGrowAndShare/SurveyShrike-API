using Application.UnitTests.Common;
using MediatR;
using Moq;
using SurveyShrike_API.Application.Surveys.Commands.CreateSurveyResponse;
using System.Threading;
using Xunit;

namespace Application.UnitTests.Surveys.Commands
{
    public class CreateSurveyResponseTests : CommandTestBase
    {
        [Fact]
        public void Handle_GivenValidRequest_ShouldRaiseSurveyCreatedNotification()
        {
            // Arrange
            var mediatorMock = new Mock<IMediator>();
            var survey = new CreateSurveyCommand.Handler(_context, mediatorMock.Object);


            // Act
            var result = survey.Handle(new CreateSurveyCommand { IP = "Test" }, CancellationToken.None);


            // Assert
            mediatorMock.Verify(m => m.Publish(It.IsAny<SurveyCreated>(), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
