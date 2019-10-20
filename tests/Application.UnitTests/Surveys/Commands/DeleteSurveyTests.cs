using Application.UnitTests.Common;
using MediatR;
using Moq;
using SurveyShrike_API.Application.Exceptions;
using SurveyShrike_API.Application.Interfaces;
using SurveyShrike_API.Application.Surveys.Commands.DeleteSurvey;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.Surveys.Commands
{
    public class DeleteSurveyTests : CommandTestBase
    {
        private readonly DeleteSurveyCommandHandler deleteSurveyCommandHandler;

        public DeleteSurveyTests()
            : base()
        {
            var getUserInformation = new Mock<IGetUserInformation>();
            getUserInformation.Setup(x => x.GetUser()).Returns(Task.FromResult("Test"));
            deleteSurveyCommandHandler  = new DeleteSurveyCommandHandler(_context, getUserInformation.Object);
        }

        [Fact]
        public async Task Handle_GivenInvalidId_ThrowsNotFoundException()
        {
            var command = new DeleteSurveyCommand { Id = Guid.NewGuid() };

            await Assert.ThrowsAsync<NotFoundException>(() => deleteSurveyCommandHandler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_GivenValidIdAndSurveyIsDeleted_ThrowsNotFoundException()
        {
        

            var command = new DeleteSurveyCommand { Id = Guid.Parse("af165dc8-aadf-4b5e-9c5d-3e2007b370ee") };

    

            await Assert.ThrowsAsync<NotFoundException>(() => deleteSurveyCommandHandler.Handle(command, CancellationToken.None));


        }

        [Fact]
        public async Task Handle_GivenValidId_DeletesTheSurvey()
        {
            var validId = Guid.Parse("af165dc8-aadf-4b5e-9c5d-3e2007b370ed");

            var command = new DeleteSurveyCommand { Id = validId };
            await deleteSurveyCommandHandler.Handle(command, CancellationToken.None);

            Assert.True(_context.Surveys.Find(validId).isDeleted);

        }
    }
}
