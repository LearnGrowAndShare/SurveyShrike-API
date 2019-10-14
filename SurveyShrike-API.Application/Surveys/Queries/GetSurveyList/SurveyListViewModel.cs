using System;
using System.Collections.Generic;
using System.Text;


/// <summary>
/// @author Ankit
/// @date - 10/14/2019 4:45:53 PM 
/// </summary>
namespace SurveyShrike_API.Application.Surveys.Queries.GetSurveyList
{
    public class SurveyListViewModel
    {
        public IList<SurveyLookupModel> Surveys { get; set; }
    }
}
