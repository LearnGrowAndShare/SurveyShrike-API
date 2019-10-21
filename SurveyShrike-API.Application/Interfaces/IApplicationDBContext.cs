using Microsoft.EntityFrameworkCore;
using SurveyShrike_API.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// @author Ankit
/// @date - 10/14/2019 3:16:27 PM 
/// </summary>
namespace SurveyShrike_API.Application.Interfaces
{
    /// <summary>
    /// Applciation db context for the DI operations.
    /// </summary>
    public interface IApplicationDBContext
    {

        /// <summary>
        ///  <see cref="Survey"> Survey</see> domain. 
        /// </summary>
        DbSet<SurveyShrike_API.Domain.Entities.Survey> Surveys { get; set; }

        /// <summary>
        ///  <see cref="Survey"> SurveyFormField </see> domain. 
        /// </summary>
        DbSet<SurveyFormField> SurveyFormFields { get; set; }

        /// <summary>
        ///  <see cref="Survey"> SurveyResponse</see> domain. 
        /// </summary>
        DbSet<SurveyResponse> SurveyResponses { get; set; }

        /// <summary>
        ///  Save changes.
        /// </summary>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
