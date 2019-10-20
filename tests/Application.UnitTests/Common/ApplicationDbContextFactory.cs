using Microsoft.EntityFrameworkCore;
using SurveyShrike_API.Domain.Entities;
using SurveyShrike_API.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UnitTests.Common
{
    public class ApplicationDbContextFactory
    {
        public static ApplicationDBContext Create()
        {
            var options = new DbContextOptionsBuilder<ApplicationDBContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new ApplicationDBContext(options);

            context.Database.EnsureCreated();


            context.Surveys.Add(new SurveyShrike_API.Domain.Entities.Survey()
            {
                Id = Guid.Parse("af165dc8-aadf-4b5e-9c5d-3e2007b370ed"),
                Title = "Test",
                CreatedBy = "Test",
                CreatedOn = DateTime.Now,
                isDeleted = false,
                ModifiedOn = DateTime.Now,
                ModifiedBy = "Test",
                SurveyForms = new List<SurveyFormField>() {
                    new SurveyFormField() {
                    FormConfiguration = "{order : 1 }",
                    FormTypes = SurveyShrike_API.Common.SurveyFieldType.SingleLineInput,
                    Id = 1,
                    Title = "Test title"
                    }
                 }
            });


            context.Surveys.Add(new SurveyShrike_API.Domain.Entities.Survey()
            {
                Id = Guid.Parse("af165dc8-aadf-4b5e-9c5d-3e2007b370ee"),
                Title = "Test - 2",
                CreatedBy = "Test_1",
                CreatedOn = DateTime.Now,
              
                ModifiedOn = DateTime.Now,
                ModifiedBy = "Test",
                isDeleted  = true,
                SurveyForms = new List<SurveyFormField>() {
                    new SurveyFormField() {
                    FormConfiguration = "{order : 1 }",
                    FormTypes = SurveyShrike_API.Common.SurveyFieldType.SingleLineInput,
                    Id = 2,
                    Title = "Test title 2"
                    }
                 }
            });

            context.SaveChangesAsync();
            return context;
        }

        public static void Destroy(ApplicationDBContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }
    }
}
