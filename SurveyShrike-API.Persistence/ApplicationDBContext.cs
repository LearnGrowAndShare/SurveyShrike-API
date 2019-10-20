using Microsoft.EntityFrameworkCore;
using SurveyShrike_API.Application.Interfaces;
using SurveyShrike_API.Domain.Entities;
using SurveyShrike_API.Domain.Entities.Interfaces.Implementations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// @author Ankit
/// @date - 10/14/2019 3:12:49 PM 
/// </summary>
namespace SurveyShrike_API.Persistence
{
    public class ApplicationDBContext: DbContext, IApplicationDBContext
    {
        public DbSet<Survey> Surveys { get ; set ; }
        public DbSet<SurveyFormField> SurveyFormFields { get ; set ; }
        public DbSet<SurveyResponse> SurveyResponses { get ; set ; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
           : base(options)
        {

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditedEntity<Guid>>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                       
                        entry.Entity.CreatedOn = DateTime.Now;
                        entry.Entity.ModifiedOn = DateTime.Now;
                        break;
                    case EntityState.Modified:

                        entry.Entity.ModifiedOn = DateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
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
