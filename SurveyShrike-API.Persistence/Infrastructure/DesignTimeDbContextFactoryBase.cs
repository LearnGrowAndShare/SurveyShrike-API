// <summary>
/// @author Ankit
/// @date - 10/14/2019 3:11:57 PM 
/// </summary>
namespace SurveyShrike_API.Persistence.Infrastructure
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.IO;

    /// <summary>
    /// Some of the EF Core Tools commands (for example, the Migrations commands) require a derived DbContext instance to be created at design time in order to gather details about the application's entity types and how they map to a database schema. In most cases, it is desirable that the DbContext thereby created is configured in a similar way to how it would be configured at run time.
    /// </summary>
    /// <typeparam name="TContext">
    /// <seealso cref="https://docs.microsoft.com/en-us/ef/core/miscellaneous/configuring-dbcontext"/>
    /// You can also tell the tools how to create your DbContext by implementing the IDesignTimeDbContextFactory<TContext> interface: If a class implementing this interface is found in either the same project as the derived DbContext or in the application's startup project, the tools bypass the other ways of creating the DbContext and use the design-time factory instead.
    /// </typeparam>
    public abstract class DesignTimeDbContextFactoryBase<TContext> :
        IDesignTimeDbContextFactory<TContext> where TContext : DbContext
    {
        protected const string ConnectionStringName = "Database";
        protected const string AspNetCoreEnvironment = "ASPNETCORE_ENVIRONMENT";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public TContext CreateDbContext(string[] args)
        {
            var basePath = Directory.GetCurrentDirectory() + string.Format("{0}..{0}SurveyShrike-API", Path.DirectorySeparatorChar);
            return Create(basePath, Environment.GetEnvironmentVariable(AspNetCoreEnvironment));
        }

        /// <summary>
        /// CreateNewInstance is an abstract method and provide a way to extend how the instance for the DB context should be prepared.
        /// </summary>
        /// <param name="options">DbContext optios to be provided as an input to the operations.</param>
        /// <returns>An instance of the Database context object.</returns>
        protected abstract TContext CreateNewInstance(DbContextOptions<TContext> options);

        /// <summary>
        /// Create method provide an input connection string for the 
        /// </summary>
        /// <param name="basePath">Base path for the appsettings.json configuration file.</param>
        /// <param name="environmentName">Asp.net Environment details for building the configuration. for example - ASP.NET_ENVIRONMENT is Development, it overrrides the value of appsettings.json with appsettings.developmnet.json.</param>
        /// <returns></returns>
        protected TContext Create(string basePath, string environmentName)
        {

            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{environmentName}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            var connectionString = configuration.GetConnectionString(ConnectionStringName);

            return Create(connectionString);
        }

        /// <summary>
        /// Create method create a new Instance of the DBContext for migrations.
        /// </summary>
        /// <param name="connectionString">Database connection string.</param>
        /// <returns></returns>
        private TContext Create(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException($"Connection string '{ConnectionStringName}' is null or empty.", nameof(connectionString));
            }

            Console.WriteLine($"DesignTimeDbContextFactoryBase.Create(string): Connection string: '{connectionString}'.");

            var optionsBuilder = new DbContextOptionsBuilder<TContext>();

            optionsBuilder.UseSqlite(connectionString);

            return CreateNewInstance(optionsBuilder.Options);
        }
    }

}
