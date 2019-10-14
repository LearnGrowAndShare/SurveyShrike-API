using SurveyShrike_API.Domain.Entities.BaseEntity;
using System;

/// <summary>
/// @author Ankit
/// @date - 10/14/2019 2:50:56 PM 
/// </summary>
namespace SurveyShrike_API.Domain.Entities
{
    public interface IAuditEntity<T> : IBaseEntity<T>
    {
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
