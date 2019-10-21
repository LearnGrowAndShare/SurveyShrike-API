using MediatR;
using SurveyShrike_API.Application.Surveys.Commands.CreateSurvey;
using System;
using System.Collections.Generic;
using System.Text;


/// <summary>
/// @author Ankit
/// @date - 10/14/2019 4:33:39 PM 
/// </summary>
namespace SurveyShrike_API.Application.Surveys.Queries.GetSurveyDetails
{  /// <summary>
   /// Type of query to help mediator know which request to operate.
   /// </summary>
    public class GetSurveyDetailQuery : IRequest<SurveyDetailModel>
    {
        /// <summary>
        /// Key of survey
        /// </summary>
        public Guid Id { get; set; }
    }
  
}
