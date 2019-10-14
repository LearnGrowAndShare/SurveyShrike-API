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
namespace SurveyShrike_API.Application.Surveys.Queries.GetSurveyDetails
{
 
   public class SurveyDetailModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public ICollection<FormFields> Forms { get; set; }

        public static Expression<Func<Survey, SurveyDetailModel>> Projection
        {
            get
            {
                return survey => new SurveyDetailModel
                {
                    Id = survey.Id,
                    Title = survey.Title,
                    Forms = survey.SurveyForms != null ? survey.SurveyForms.Select(x => 
                    new FormFields() {
                        Id = x.Id,
                        FormConfiguration = x.FormConfiguration, 
                        FormTypes = x.FormTypes, 
                        Title = x.Title 
                    }).ToList()
                    : null
                };
            }
        }

        public static SurveyDetailModel Create(Survey customer)
        {
            return Projection.Compile().Invoke(customer);
        }
    }
}
