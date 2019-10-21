using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;


/// <summary>
/// @author Ankit
/// @date - 10/14/2019 4:34:06 PM 
/// </summary>
namespace SurveyShrike_API.Application.Surveys.Queries.GetSurveyDetails
{
    /// <summary>
    /// GetSurveyDetailQueryValidator validation for the ID
    /// </summary>
    public class GetSurveyDetailQueryValidator : AbstractValidator<GetSurveyDetailQuery>
    {
        /// <summary>
        /// Constructor of GetSurveyDetailQueryValidator
        /// </summary>
        public GetSurveyDetailQueryValidator()
        {
            RuleFor(v => v.Id).NotEmpty();
        }
    }
}
