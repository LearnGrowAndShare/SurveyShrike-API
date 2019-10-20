using Application.UnitTests.Common;
using AutoMapper;
using Moq;
using Shouldly;
using SurveyShrike_API.Application.Interfaces;
using SurveyShrike_API.Application.Surveys.Queries.GetSurveyList;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.Surveys.Queries
{
    [Collection("QueryCollection")]
    public class GetSurveyListQueryHandlerTests
    {
        private readonly IApplicationDBContext _context;
        private readonly IMapper _mapper;
        private readonly IGetUserInformation _getUserInformation; 
        public GetSurveyListQueryHandlerTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
            fixture.MockUserInformation.Setup(x => x.GetUser()).Returns(Task.FromResult("Test"));
            _getUserInformation = fixture.MockUserInformation.Object;
        }

        [Fact]
        public async Task GetAllSurveyForLoggedInUserTest()
        {
            var handler = new GetSurveyListQueryHandler(_context, _mapper, _getUserInformation);

            var result = await handler.Handle(new GetSurveyListQuery(), CancellationToken.None);

            result.ShouldBeOfType<SurveyListViewModel>();

            result.Surveys.Count.ShouldBe(1);
        }
    }
}
