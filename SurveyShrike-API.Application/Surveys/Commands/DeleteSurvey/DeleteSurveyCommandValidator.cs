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

    public class DeleteSurveyCommandValidator : AbstractValidator<DeleteSurveyCommand>
    {
        public DeleteSurveyCommandValidator()
        {
            RuleFor(v => v.Id).NotEmpty();
        }
    }
}
