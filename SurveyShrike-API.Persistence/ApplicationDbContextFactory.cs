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
    /// 
    /// </summary>
    public class ApplicationDbContextFactory : DesignTimeDbContextFactoryBase<ApplicationDBContext>
    {
        protected override ApplicationDBContext CreateNewInstance(DbContextOptions<ApplicationDBContext> options)
        {
            return new ApplicationDBContext(options);
        }
    }
}
