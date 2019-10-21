using MediatR;
using System;

/// <summary>
/// @author Ankit
/// @date - 10/14/2019 4:23:54 PM 
/// </summary>
namespace SurveyShrike_API.Application.Surveys.Commands.DeleteSurvey
{
    /// <summary>
    /// Delete Survey Command
    /// </summary>
    public class DeleteSurveyCommand : IRequest
    {
        /// <summary>
        /// Key to look for survey
        /// </summary>
        public Guid Id { get; set; }
    }
   
}
