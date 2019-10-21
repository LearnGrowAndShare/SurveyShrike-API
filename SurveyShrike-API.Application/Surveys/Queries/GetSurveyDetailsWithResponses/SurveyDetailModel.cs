using SurveyShrike_API.Application.Surveys.Commands.CreateSurvey;
using SurveyShrike_API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;


/// <summary>
/// @author Ankit
/// @date - 10/14/2019 4:33:28 PM 
/// </summary>
namespace SurveyShrike_API.Application.Surveys.Queries.GetSurveyDetailsWithResponses
{
 
   public class SurveyDetailModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public ICollection<FormFieldExtended> Forms { get; set; }

        public static Expression<Func<Survey, SurveyDetailModel>> Projection
        {
            get
            {
                return survey => new SurveyDetailModel
                {
                    Id = survey.Id,
                    Title = survey.Title,
                    Forms = survey.SurveyForms != null ? survey.SurveyForms.Select(x => 
                    new FormFieldExtended() {
                        FormConfiguration = x.FormConfiguration, 
                        FormTypes = x.FormTypes, 
                        Title = x.Title, 
                        Responses = x.SurveyResponses == null ?
                        new List<Tuple<string, string>>() : x.SurveyResponses.Select(x => 
                                            new Tuple<string, string>(x.ReportedIP, x.Response)).ToList()
                    }).ToList()
                    : null
                };
            }
        }

        public static SurveyDetailModel Create(Survey survey)
        {
            return Projection.Compile().Invoke(survey);
        }
    }
}
