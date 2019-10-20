using AutoMapper;
using Moq;
using SurveyShrike_API.Application.Infrastructure.Automapper;
using SurveyShrike_API.Application.Interfaces;
using SurveyShrike_API.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Application.UnitTests.Common
{
    public class QueryTestFixture : IDisposable
    {
        public ApplicationDBContext Context { get; private set; }
        public IMapper Mapper { get; private set; }

        public Mock<IGetUserInformation> MockUserInformation { get; private set; }

        public QueryTestFixture()
        {
            Context = ApplicationDbContextFactory.Create();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });

            Mapper = configurationProvider.CreateMapper();

            MockUserInformation = new Mock<IGetUserInformation>();
        }

        public void Dispose()
        {
            ApplicationDbContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}
