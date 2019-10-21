using Microsoft.EntityFrameworkCore;
using SurveyShrike_API.Persistence.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;


/// <summary>
/// @author Ankit
/// @date - 10/14/2019 3:13:45 PM 
/// </summary>
namespace SurveyShrike_API.Persistence
{
    /// <summary>
    /// Some of the EF Core Tools commands (for example, the Migrations commands) require a derived DbContext instance to be 
    /// created at design time in order to gather details about the application's entity types and how they map to a database schema. 
    /// In most cases, it is desirable that the DbContext thereby created is configured in a similar way to how it would be configured 
    /// at run time.
    /// </summary>
    public class ApplicationDbContextFactory : DesignTimeDbContextFactoryBase<ApplicationDBContext>
    {
        protected override ApplicationDBContext CreateNewInstance(DbContextOptions<ApplicationDBContext> options)
        {
            return new ApplicationDBContext(options);
        }
    }
}
