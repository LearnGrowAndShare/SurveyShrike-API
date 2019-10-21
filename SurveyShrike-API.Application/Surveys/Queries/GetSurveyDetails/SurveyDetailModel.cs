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
 /// <summary>
 /// Respose for the Survey Details model
 /// </summary>
   public class SurveyDetailModel
    {
        /// <summary>
        /// Key for survey
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Title of the survey
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Form field configuration
        /// </summary>
        public ICollection<FormFields> Forms { get; set; }

        /// <summary>
        /// Projection to map
        /// </summary>
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

        /// <summary>
        /// create a suvey model
        /// </summary>
        /// <param name="survey">survey</param>
        /// <returns>survey</returns>
        public static SurveyDetailModel Create(Survey survey)
        {
            return Projection.Compile().Invoke(survey);
        }
    }
}
