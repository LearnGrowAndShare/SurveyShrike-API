using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;


/// <summary>
/// @author Ankit
/// @date - 10/14/2019 4:22:46 PM 
/// </summary>
namespace SurveyShrike_API.Application.Surveys.Commands.CreateSurveyResponse
{
  public class CreateSurveyCommandValidator : AbstractValidator<CreateSurveyCommand>
    {
        public CreateSurveyCommandValidator()
        {
            RuleFor(x => x.FormFields).NotNull();
        }
    }
}
