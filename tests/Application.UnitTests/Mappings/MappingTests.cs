using AutoMapper;
using SurveyShrike_API.Application.Surveys.Queries.GetSurveyList;
using SurveyShrike_API.Domain.Entities;
using System;
using System.Collections.Generic;
using Shouldly;
using Xunit;
using SurveyShrike_API.Application.Surveys.Queries.GetSurveyDetails;

namespace Application.UnitTests.Mappings
{
    public class MappingTests : IClassFixture<MappingTestsFixture>
    {
        private readonly IConfigurationProvider _configuration;
        private readonly IMapper _mapper;

        public MappingTests(MappingTestsFixture fixture)
        {
            _configuration = fixture.ConfigurationProvider;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public void ShouldHaveValidConfiguration()
        {
            _configuration.AssertConfigurationIsValid();
        }

        [Fact]
        public void ShouldMapSurveyToSurveyLookupModel()
        {
            var entity = new Survey();

            var result = _mapper.Map<SurveyLookupModel>(entity);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<SurveyLookupModel>();
        }

    }
    
}
