using Microsoft.EntityFrameworkCore;
using SurveyShrike_API.Domain.Entities;
using SurveyShrike_API.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Shouldly;

namespace Persistence.UnitTests
{
    public class ApplicationDbContextTests : IDisposable
    {
        private readonly ApplicationDBContext _context;


        public ApplicationDbContextTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDBContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _context = new ApplicationDBContext(options);
            _context.Surveys.Add(new SurveyShrike_API.Domain.Entities.Survey() {
                 Id = Guid.NewGuid(),
                 Title = "Test",
                 CreatedBy = "Test",
                 CreatedOn = DateTime.Now,
                 isDeleted = false,
                 ModifiedOn = DateTime.Now,
                 ModifiedBy = "Test",
                 SurveyForms = new List<SurveyFormField> () {
                    new SurveyFormField() { 
                    FormConfiguration = "{order : 1 }",
                    FormTypes = SurveyShrike_API.Common.SurveyFieldType.SingleLineInput,
                    Id = 1,
                    Title = "Test title"
                    }
                 }
            });

            _context.SaveChanges();
        }

        [Fact]
        public async Task SaveChangesAsync_GivenNewSurvery_ShouldSetCreatedProperties()
        {
            var survey = new SurveyShrike_API.Domain.Entities.Survey()
            {
                Id = Guid.NewGuid(),
                Title = "Test",
                CreatedBy = "Test",
                isDeleted = false,
                ModifiedBy = "Test",
                SurveyForms = new List<SurveyFormField>() {
                    new SurveyFormField() {
                    FormConfiguration = "{order : 1 }",
                    FormTypes = SurveyShrike_API.Common.SurveyFieldType.SingleLineInput,
                    Id = 2,
                    Title = "Test title"
                    }
                 }
            };

            _context.Surveys.Add(survey);

            await _context.SaveChangesAsync();

            survey.CreatedOn.ShouldNotBeNull();
            survey.CreatedOn.ShouldBeLessThan(DateTime.Now);
        }

        [Fact]
        public async Task SaveChangesAsync_GivenExistingSurvey_ShouldSetLastModifiedProperties()
        {
            var survey = await _context.Surveys.FirstAsync();
            var createdOn = survey.CreatedOn;
            var modifiedOn = survey.ModifiedOn;
            survey.Title = "New Title";

            await _context.SaveChangesAsync();

            survey.ModifiedOn.ShouldNotBeNull();
            survey.ModifiedOn.ShouldBeLessThan(DateTime.Now);
            survey.CreatedOn.ShouldBe(createdOn);
            survey.ModifiedOn.ShouldNotBe(modifiedOn);
        }


        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
