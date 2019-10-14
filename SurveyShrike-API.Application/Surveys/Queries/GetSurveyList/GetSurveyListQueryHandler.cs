using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SurveyShrike_API.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// @author Ankit
/// @date - 10/14/2019 4:48:11 PM 
/// </summary>
namespace SurveyShrike_API.Application.Surveys.Queries.GetSurveyList
{
    public class GetSurveyListQueryHandler : IRequestHandler<GetSurveyListQuery, SurveyListViewModel>
    {
        private readonly IApplicationDBContext _context;
        private readonly IMapper _mapper;

        public GetSurveyListQueryHandler(IApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SurveyListViewModel> Handle(GetSurveyListQuery request, CancellationToken cancellationToken)
        {
            return new SurveyListViewModel
            {
                Surveys = await _context.Surveys.ProjectTo<SurveyLookupModel>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken)
            };
        }
    }
}
