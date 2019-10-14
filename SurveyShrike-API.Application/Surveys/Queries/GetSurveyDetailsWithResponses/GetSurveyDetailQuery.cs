using MediatR;
using SurveyShrike_API.Application.Surveys.Commands.CreateSurvey;
using System;
using System.Collections.Generic;
using System.Text;


/// <summary>
/// @author Ankit
/// @date - 10/14/2019 4:33:39 PM 
/// </summary>
namespace SurveyShrike_API.Application.Surveys.Queries.GetSurveyDetailsWithResponses
{
    public class GetSurveyDetailQuery : IRequest<SurveyDetailModel>
    {
        public Guid Id { get; set; }
    }
  
}
