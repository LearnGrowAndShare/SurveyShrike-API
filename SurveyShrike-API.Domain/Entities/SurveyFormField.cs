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
    /// Provides the survey form configuration
    /// </summary>
    public class SurveyFormField : IBaseEntity<int>
    {
        /// <summary>
        /// Id is a Primary key for the table.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Title (label) for the form field
        /// </summary>
        public string Title { get; set; }
        
        /// <summary>
        /// Form field Type ,for example - Text,dropdown.
        /// <seealso cref="SurveyFieldType"/> for more details.
        /// </summary>
        public SurveyFieldType FormTypes { get; set; }

        /// <summary>
        /// Form configuration have json configuration for the form, like list value for the drop downs.
        /// </summary>
        public string FormConfiguration { get; set; }

        /// <summary>
        /// Has one to one related to the survey.
        /// <seealso cref="Survey"/>
        /// </summary>
        public virtual Survey Survey { get; set; }

        /// <summary>
        /// Has one to many related to the survey responses. 
        /// <seealso cref="SurveyResponse"/>
        /// </summary>
        public virtual ICollection<SurveyResponse> SurveyResponses { get; private set; }
        
    }
}
