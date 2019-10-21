using System;
using System.Collections.Generic;
using System.Text;


/// <summary>
/// @author Ankit
/// @date - 10/14/2019 4:45:53 PM 
/// </summary>
namespace SurveyShrike_API.Application.Surveys.Queries.GetSurveyList
{
    /// <summary>
    /// SurveyListViewModel
    /// </summary>
    public class SurveyListViewModel
    {
        /// <summary>
        /// Final reposne of the query
        /// </summary>
        public IList<SurveyLookupModel> Surveys { get; set; }
    }
}
