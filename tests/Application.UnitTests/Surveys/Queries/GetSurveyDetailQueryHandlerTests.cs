using Application.UnitTests.Common;
using AutoMapper;
using Shouldly;
using SurveyShrike_API.Application.Exceptions;
using SurveyShrike_API.Application.Interfaces;
using SurveyShrike_API.Application.Surveys.Queries.GetSurveyDetails;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.Surveys.Queries
{
    [Collection("QueryCollection")]
    public class GetSurveyDetailQueryHandlerTests
    {
        private readonly IApplicationDBContext _context;

        public GetSurveyDetailQueryHandlerTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;

        }

        [Fact]
        public async Task GetSurveyDetails_ForLoggedIn_User_BasedOnIdTest()
        {
            var handler = new GetSurveyDetailQueryHandler(_context);

            var result = await handler.Handle(new GetSurveyDetailQuery() {Id = Guid.Parse("af165dc8-aadf-4b5e-9c5d-3e2007b370ed") }, CancellationToken.None);
             
            result.ShouldBeOfType<SurveyDetailModel>();

            result.Title.ShouldBe("Test");
        }

        [Fact]
        public async Task GetSurveyDetails_Should_Throws_Not_Found_Exception_On_Not_Existing_Id_Test()
        {
            var handler = new GetSurveyDetailQueryHandler(_context);
            await Assert.ThrowsAsync<NotFoundException>(async () => await handler.Handle(new GetSurveyDetailQuery() { Id = Guid.NewGuid() }, CancellationToken.None));
          
        }

        [Fact]
        public async Task GetSurveyDetails_Should_Throws_Not_Found_Exception_For_Deleted_Survey()
        {
            var handler = new GetSurveyDetailQueryHandler(_context);
            await Assert.ThrowsAsync<NotFoundException>(async () => await handler.Handle(new GetSurveyDetailQuery() { Id = Guid.Parse("af165dc8-aadf-4b5e-9c5d-3e2007b370ee") }, CancellationToken.None));

        }
        
    }
}


