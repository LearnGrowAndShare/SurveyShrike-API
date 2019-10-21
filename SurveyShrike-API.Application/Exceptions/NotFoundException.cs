using System;
using System.Collections.Generic;
using System.Text;


/// <summary>
/// @author Ankit
/// @date - 10/14/2019 3:56:18 PM 
/// </summary>
namespace SurveyShrike_API.Application.Exceptions
{
    /// <summary>
    /// The exception that is thrown when a null reference found for the provided Id/Key to look for the entity.
    /// </summary>
    public class NotFoundException : Exception
    {
        public NotFoundException(string name, object key)
            : base($"Entity \"{name}\" ({key}) was not found.")
        {
        }
    }
}
