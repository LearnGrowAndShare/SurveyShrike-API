using SurveyShrike_API.Domain.Entities.Interfaces.Implementations;
using System;
using System.Collections.Generic;

/// <summary>
/// @author Ankit
/// @date - 10/14/2019 2:54:26 PM 
/// </summary>
namespace SurveyShrike_API.Domain.Entities
{
    /// <summary>
    /// Survey domain. It contains all the resposibility of the describing the survey.
    /// It is an <seealso cref="SurveyShrike_API.Domain.Entities.Interfaces.Implementations.AuditedEntity{System.Guid}">audited</seealso> and <seealso cref="SurveyShrike_API.Domain.Entities.ISoftDeleteEntity">soft deleted </seealso> entity.
    /// </summary>
    public class Survey : AuditedEntity<Guid>, ISoftDeleteEntity
    {
        /// <summary>
        /// Title for the survey
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Deleted value true indicated the survey is marked deleted/archived, so should not be actively visible on GUI.
        /// </summary>
        public bool isDeleted { get; set; }

        /// <summary>
        /// Survey form configurations.
        /// <seealso cref="SurveyFormField"> SurveyFormField </seealso> for details about the field configuration
        /// </summary>
        public virtual ICollection<SurveyFormField> SurveyForms { get;  set; }
    }
}
