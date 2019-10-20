using Application.UnitTests.Common;
using MediatR;
using Moq;
using SurveyShrike_API.Application.Interfaces;
using SurveyShrike_API.Application.Surveys.Commands.CreateSurvey;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace Application.UnitTests.Surveys.Commands
{
    public class CreateSurveyTests : CommandTestBase
    {
        [Fact]
        public void Handle_GivenValidRequest_ShouldRaiseSurveyCreatedNotification()
        {
            // Arrange
            var mediatorMock = new Mock<IMediator>();
            var getUserInformation = new Mock<IGetUserInformation>();
            var survey = new CreateSurveyCommand.Handler(_context, mediatorMock.Object, getUserInformation.Object);
            

            // Act
            var result = survey.Handle(new CreateSurveyCommand { Title = "Test" }, CancellationToken.None);


            // Assert
            mediatorMock.Verify(m => m.Publish(It.IsAny<SurveyCreated>(), It.IsAny<CancellationToken>()), Times.Once);
        }
    }

}
