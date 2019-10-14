using System;
using System.Collections.Generic;
using System.Text;


/// <summary>
/// @author Ankit
/// @date - 10/14/2019 2:56:49 PM 
/// </summary>
namespace SurveyShrike_API.Domain.Entities.Interfaces.Implementations
{
    public abstract class AuditedEntity<T> : IAuditEntity<T>
    {
        public T Id { get; set; }


        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
