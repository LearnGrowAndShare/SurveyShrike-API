using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;


/// <summary>
/// @author Ankit
/// @date - 10/14/2019 4:30:55 PM 
/// </summary>
namespace SurveyShrike_API.Application.Surveys.Commands.UpdateSurvey
{

    public class UpdateSurveyCommandValidator : AbstractValidator<UpdateSurveyCommand>
    {
        public UpdateSurveyCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Title).MaximumLength(80);

        }


    }
}
