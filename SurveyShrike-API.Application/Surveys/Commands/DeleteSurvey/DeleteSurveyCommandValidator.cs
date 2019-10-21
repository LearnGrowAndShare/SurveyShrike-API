using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;


/// <summary>
/// @author Ankit
/// @date - 10/14/2019 4:26:22 PM 
/// </summary>
namespace SurveyShrike_API.Application.Surveys.Commands.DeleteSurvey
{
    /// <summary>
    /// DeleteSurveyCommandValidator
    /// </summary>
    public class DeleteSurveyCommandValidator : AbstractValidator<DeleteSurveyCommand>
    {
        /// <summary>
        /// DeleteSurveyCommandValidator
        /// </summary>
        public DeleteSurveyCommandValidator()
        {
            RuleFor(v => v.Id).NotEmpty();
        }
    }
}
