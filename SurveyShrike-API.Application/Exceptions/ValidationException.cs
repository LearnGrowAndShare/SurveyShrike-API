using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


/// <summary>
/// @author Ankit
/// @date - 10/14/2019 3:56:35 PM 
/// </summary>
namespace SurveyShrike_API.Application.Exceptions
{
    /// <summary>
    /// The exception that is thrown when the property/field of the class fails to fullfil FluentValidation definations.
    /// </summary>
    public class ValidationException : Exception
    {
        /// <summary>
        /// Constructor of ValidationException
        /// </summary>
        public ValidationException()
            : base("One or more validation failures have occurred.")
        {
            Failures = new Dictionary<string, string[]>();
        }

        /// <summary>
        /// Constructor of ValidationException
        /// </summary>
        /// <param name="failures">List of all the validation failures. <seealso cref="ValidationFailure"/></param>
        public ValidationException(List<ValidationFailure> failures)
            : this()
        {
            var propertyNames = failures
                .Select(e => e.PropertyName)
                .Distinct();

            foreach (var propertyName in propertyNames)
            {
                var propertyFailures = failures
                    .Where(e => e.PropertyName == propertyName)
                    .Select(e => e.ErrorMessage)
                    .ToArray();

                Failures.Add(propertyName, propertyFailures);
            }
        }

        /// <summary>
        /// Dictionary with list of all the failure.
        /// </summary>
        public IDictionary<string, string[]> Failures { get; }
    }
}
