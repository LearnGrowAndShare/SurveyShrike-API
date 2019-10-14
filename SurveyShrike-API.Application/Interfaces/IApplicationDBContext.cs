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
    public interface IApplicationDBContext
    {
        DbSet<SurveyShrike_API.Domain.Entities.Survey> Surveys { get; set; }

        DbSet<SurveyFormField> SurveyFormFields { get; set; }

        DbSet<SurveyResponse> SurveyResponses { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
