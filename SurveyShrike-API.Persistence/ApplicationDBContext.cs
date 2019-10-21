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
    /// <summary>
    /// Application DB context for the API application, provides all database operations
    /// </summary>
    /// <remarks>
    /// For any database operation for design time should be changed here. 
    /// This is the only place which  <see href="https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/">df migration or update-database or Add-Migration /> command would look for.
    /// </remarks>
    public class ApplicationDBContext: DbContext, IApplicationDBContext
    {
        public DbSet<Survey> Surveys { get ; set ; }
        public DbSet<SurveyFormField> SurveyFormFields { get ; set ; }
        public DbSet<SurveyResponse> SurveyResponses { get ; set ; }

        /// <summary>
        /// ApplicationDBContext class constructor. It has responsibility to create object.
        /// </summary>
        /// <param name="options"></param>
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
           : base(options)
        {

        }

        /// <summary>
        /// Description for SaveChangesAsync.
        /// </summary>
        /// <param name="cancellationToken"> Cancellation token, Propagates notification that operations should be canceled.</param>
        /// <seealso cref="System.Threading.CancellationToken">
        /// Cancellation token.
        /// </seealso>
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
        /// This method is called when the model for a derived context has been initialized, but before the model has been locked down and used to initialize the context. The default implementation of this method does nothing, but it can be overridden in a derived class such that the model can be further configured before it is locked down.
        /// </summary>
        /// <param name="modelBuilder">The builder that defines the model for the context being created.</param>
        /// <remarks>
        /// Typically, this method is called only once when the first instance of a derived context 
        /// is created.The model for that context is then cached and is for all further instances of
        /// the context in the app domain.This caching can be disabled by setting the ModelCaching 
        /// property on the given ModelBuilder, but note that this can seriously degrade performance.
        /// More control over caching is provided through use of the DbModelBuilder and DbContextFactory
        /// classes directly.
        /// </remarks>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDBContext).Assembly);
            base.OnModelCreating(modelBuilder);


        }
    }
}
