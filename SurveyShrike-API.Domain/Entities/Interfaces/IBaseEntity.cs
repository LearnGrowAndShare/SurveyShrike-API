using System;
using System.Collections.Generic;
using System.Text;


/// <summary>
/// @author Ankit
/// @date - 10/14/2019 2:50:01 PM 
/// </summary>
namespace SurveyShrike_API.Domain.Entities.BaseEntity
{
    public interface IBaseEntity<T>
    {
        public T Id { get; set; }
    }
}
