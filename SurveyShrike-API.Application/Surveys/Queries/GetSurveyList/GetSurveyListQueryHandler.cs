using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SurveyShrike_API.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Security.Claims;
/// <summary>
/// @author Ankit
/// @date - 10/14/2019 4:48:11 PM 
/// </summary>
namespace SurveyShrike_API.Application.Surveys.Queries.GetSurveyList
{
    public class GetSurveyListQueryHandler : IRequestHandler<GetSurveyListQuery, SurveyListViewModel>
    {
        private readonly IApplicationDBContext _context;
        private readonly IGetUserInformation _getUserInformation;
        

        private readonly IMapper _mapper;

        public GetSurveyListQueryHandler(IApplicationDBContext context, IMapper mapper, IGetUserInformation getUserInformation)
        {
            _context = context;
            _mapper = mapper;
            _getUserInformation = getUserInformation;

        }

        public async Task<SurveyListViewModel> Handle(GetSurveyListQuery request, CancellationToken cancellationToken)
        {
            var email = await _getUserInformation.GetUser();

            return new SurveyListViewModel
            {
                Surveys = await _context.Surveys.Where(x => x.CreatedBy == email && !x.isDeleted ).ProjectTo<SurveyLookupModel>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken)
            };
        }
    }
}
