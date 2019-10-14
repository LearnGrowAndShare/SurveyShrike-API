using Microsoft.EntityFrameworkCore;
using SurveyShrike_API.Application.Interfaces;
using SurveyShrike_API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;


/// <summary>
/// @author Ankit
/// @date - 10/14/2019 3:12:49 PM 
/// </summary>
namespace SurveyShrike_API.Persistence
{
    public class ApplicationDBContext: DbContext, IApplicationDBContext
    {
       DbSet<Survey> IApplicationDBContext.Surveys { get ; set ; }
        DbSet<SurveyFormField> IApplicationDBContext.SurveyFormFields { get ; set ; }
        DbSet<SurveyResponse> IApplicationDBContext.SurveyResponses { get ; set ; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
           : base(options)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDBContext).Assembly);
            base.OnModelCreating(modelBuilder);


        }
    }
}
