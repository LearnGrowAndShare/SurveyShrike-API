using SurveyShrike_API.Domain.Entities.Interfaces.Implementations;
using System;
using System.Collections.Generic;

/// <summary>
/// @author Ankit
/// @date - 10/14/2019 2:54:26 PM 
/// </summary>
namespace SurveyShrike_API.Domain.Entities
{
    public class Survey : AuditedEntity<Guid>, ISoftDeleteEntity
    {
        public string Title { get; set; }

        public bool isDeleted { get; set; }

        public virtual ICollection<SurveyFormField> SurveyForms { get;  set; }
    }
}
