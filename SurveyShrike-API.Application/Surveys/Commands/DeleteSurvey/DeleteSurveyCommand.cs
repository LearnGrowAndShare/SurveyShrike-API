using MediatR;
using System;

/// <summary>
/// @author Ankit
/// @date - 10/14/2019 4:23:54 PM 
/// </summary>
namespace SurveyShrike_API.Application.Surveys.Commands.DeleteSurvey
{
    public class DeleteSurveyCommand : IRequest
    {
        public Guid Id { get; set; }
    }
   
}
