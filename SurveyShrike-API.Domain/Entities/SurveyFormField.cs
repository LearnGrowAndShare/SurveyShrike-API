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
    public class SurveyFormField : IBaseEntity<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public SurveyFieldType FormTypes { get; set; }
        public string FormConfiguration { get; set; }

        public virtual Survey Survey { get; set; }
        public virtual ICollection<SurveyResponse> SurveyResponses { get; private set; }
        
    }
}
