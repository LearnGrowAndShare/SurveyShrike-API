using MediatR;

/// <summary>
/// @author Ankit
/// @date - 10/14/2019 4:47:20 PM 
/// </summary>
namespace SurveyShrike_API.Application.Surveys.Queries.GetSurveyList
{
    /// <summary>
    /// Type of query to help mediator know which request to operate.
    /// </summary>
    public class GetSurveyListQuery : IRequest<SurveyListViewModel>
    {
    }

}
