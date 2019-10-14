using AutoMapper;
using SurveyShrike_API.Application.Interfaces.Mapping;
using SurveyShrike_API.Domain.Entities;

namespace SurveyShrike_API.Application.Surveys.Queries.GetSurveyList
{
    public class SurveyLookupModel : IHaveCustomMapping
    {
        public string Id { get; set; }
        public string Title { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Survey, SurveyLookupModel>()
                .ForMember(cDTO => cDTO.Id, opt => opt.MapFrom(c => c.Id))
                .ForMember(cDTO => cDTO.Title, opt => opt.MapFrom(c => c.Title));
        }
    }
}