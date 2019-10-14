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
    public class SurveyResponse : IBaseEntity<int>
    {
        public int Id { get; set; }
        public string Response { get; set; }
        public DateTime ReportedAt { get; set; }
        public string ReportedIP { get; set; }
        
        public virtual SurveyFormField SurveyFormField { get; set; }
    }
}
