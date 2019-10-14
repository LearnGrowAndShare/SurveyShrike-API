using SurveyShrike_API.Common;
using System;
using System.Collections.Generic;
using System.Text;


/// <summary>
/// @author Ankit
/// @date - 10/14/2019 4:05:59 PM 
/// </summary>
namespace SurveyShrike_API.Application.Surveys.Commands.CreateSurvey
{
    public class FormFields
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public SurveyFieldType FormTypes { get; set; }
        public string FormConfiguration { get; set; }

    }
}
