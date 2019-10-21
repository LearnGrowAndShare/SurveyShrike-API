using SurveyShrike_API.Common;
using SurveyShrike_API.Domain.Entities.BaseEntity;
using SurveyShrike_API.Domain.Entities.Interfaces.Implementations;
using System;
using System.Collections.Generic;
using System.Text;


/// <summary>
/// @author Ankit
/// @date - 10/14/2019 2:54:26 PM 
/// </summary>
namespace SurveyShrike_API.Domain.Entities
{
    /// <summary>
    /// Survey response is contains the response for the survey form fields, explicitly denotes the survey response. 
    /// </summary>
    public class SurveyResponse : IBaseEntity<int>
    {
        /// <summary>
        /// Primary key 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Response entred by the user for the survey.
        /// </summary>
        public string Response { get; set; }

        /// <summary>
        /// What time the response was provided.
        /// </summary>
        public DateTime ReportedAt { get; set; }

        /// <summary>
        /// IP of the user who placed response.
        /// </summary>
        public string ReportedIP { get; set; }

        /// <summary> 
        /// It has one to many relation ship with the <see cref="SurveyFormField"> SurveyFormField </see>
        /// </summary>
        public virtual SurveyFormField SurveyFormField { get; set; }
    }
}
