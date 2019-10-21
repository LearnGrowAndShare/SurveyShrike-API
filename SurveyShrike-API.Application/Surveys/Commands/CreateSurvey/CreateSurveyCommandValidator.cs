using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;


/// <summary>
/// @author Ankit
/// @date - 10/14/2019 4:22:46 PM 
/// </summary>
namespace SurveyShrike_API.Application.Surveys.Commands.CreateSurvey
{
    /// <summary>
    /// Create survey validation
    /// </summary>
  public class CreateSurveyCommandValidator : AbstractValidator<CreateSurveyCommand>
    {
        /// <summary>
        /// Constructor for CreateSurveyCommandValidator, and has all defination of validation rules.
        /// </summary>
        public CreateSurveyCommandValidator()
        {
            RuleFor(x => x.Title).NotNull();
        }
    }
}
