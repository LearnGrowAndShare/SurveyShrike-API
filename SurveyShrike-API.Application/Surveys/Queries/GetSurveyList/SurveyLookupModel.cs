using AutoMapper;
using SurveyShrike_API.Application.Interfaces.Mapping;
using SurveyShrike_API.Domain.Entities;

namespace SurveyShrike_API.Application.Surveys.Queries.GetSurveyList
{
    /// <summary>
    /// SurveyLookupModel, the object return when looked for the list of surveys
    /// </summary>
    public class SurveyLookupModel : IHaveCustomMapping
    {
        /// <summary>
        /// Key for survey
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Title for the project
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Create mapping using Auto mapper
        /// </summary>
        /// <param name="configuration">Auto mapper configuration</param>
        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Survey, SurveyLookupModel>()
                .ForMember(cDTO => cDTO.Id, opt => opt.MapFrom(c => c.Id))
                .ForMember(cDTO => cDTO.Title, opt => opt.MapFrom(c => c.Title));
        }
    }
}