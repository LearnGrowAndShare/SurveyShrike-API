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
    /// <summary>
    /// GetSurveyListQueryHandler
    /// </summary>
    public class GetSurveyListQueryHandler : IRequestHandler<GetSurveyListQuery, SurveyListViewModel>
    {
        /// <summary>
        /// Application DB Context
        /// </summary>
        private readonly IApplicationDBContext _context;

        /// <summary>
        /// Get user information
        /// </summary>
        private readonly IGetUserInformation _getUserInformation;
        
        /// <summary>
        /// IMapper to perform auto mapping
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// GetSurveyListQueryHandler
        /// </summary>
        /// <param name="context">Application db context</param>
        /// <param name="mapper">mapper</param>
        /// <param name="getUserInformation">get user information</param>
        public GetSurveyListQueryHandler(IApplicationDBContext context, IMapper mapper, IGetUserInformation getUserInformation)
        {
            _context = context;
            _mapper = mapper;
            _getUserInformation = getUserInformation;

        }

        /// <summary>
        /// Handle the request
        /// </summary>
        /// <param name="request">request object</param>
        /// <param name="cancellationToken">cancellation token</param>
        /// <returns>SurveyListViewModel</returns>
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
