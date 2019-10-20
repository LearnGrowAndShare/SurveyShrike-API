using Application.UnitTests.Common;
using Moq;
using Shouldly;
using SurveyShrike_API.Application.Exceptions;
using SurveyShrike_API.Application.Interfaces;
using SurveyShrike_API.Application.Surveys.Commands.UpdateSurvey;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.Surveys.Commands
{

    public class UpdateSurveyTests : CommandTestBase
    {
        [Fact]
        public async void Handle_GivenValidRequest_ShouldUpdateSurvey()
        {
            // Arrange
            var getUserInformation = new Mock<IGetUserInformation>();
            getUserInformation.Setup(x => x.GetUser()).Returns(Task.FromResult("Test"));
            var survey = new UpdateSurveyCommand.Handler(_context, getUserInformation.Object);


            // Act
            var result = await survey.Handle(new UpdateSurveyCommand { Title = "Test-New" , Id = Guid.Parse("af165dc8-aadf-4b5e-9c5d-3e2007b370ed")}, CancellationToken.None);


            // Assert
            var getSurvey = _context.Surveys.Find(Guid.Parse("af165dc8-aadf-4b5e-9c5d-3e2007b370ed"));
            getSurvey.Title.ShouldBe("Test-New");
        }

        [Fact]
        public async void Handle_GivenValidRequestAndSurveyNotExist_ShouldRaiseNotFoundException()
        {
            // Arrange
            var getUserInformation = new Mock<IGetUserInformation>();
            var survey = new UpdateSurveyCommand.Handler(_context, getUserInformation.Object);


            await Assert.ThrowsAsync<NotFoundException>(() => survey.Handle(new UpdateSurveyCommand { Title = "Test-New", Id = Guid.Parse("af165dc8-afdf-4b5e-9c5d-3e2007b370ed") }, CancellationToken.None));

        }


        [Fact]
        public async void Handle_GivenValidRequestAndSurveyIsDeleted_ShouldRaiseNotFoundException()
        {
            // Arrange
            var getUserInformation = new Mock<IGetUserInformation>();
            var survey = new UpdateSurveyCommand.Handler(_context, getUserInformation.Object);


            await Assert.ThrowsAsync<NotFoundException>(() => survey.Handle(new UpdateSurveyCommand { Title = "Test-New", Id = Guid.Parse("af165dc8-aadf-4b5e-9c5d-3e2007b370ee") }, CancellationToken.None));

        }
    }
}
