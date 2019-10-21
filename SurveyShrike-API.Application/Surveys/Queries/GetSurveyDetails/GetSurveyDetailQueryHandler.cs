using MediatR;
using SurveyShrike_API.Application.Exceptions;
using SurveyShrike_API.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// @author Ankit
/// @date - 10/14/2019 4:33:51 PM 
/// </summary>
namespace SurveyShrike_API.Application.Surveys.Queries.GetSurveyDetails
{
    /// <summary>
    /// GetSurveyDetailQueryHandler
    /// </summary>
    public class GetSurveyDetailQueryHandler : IRequestHandler<GetSurveyDetailQuery, SurveyDetailModel>
    {
        /// <summary>
        /// application db context
        /// </summary>
        private readonly IApplicationDBContext _context;

        /// <summary>
        /// Constructor of GetSurveyDetailQueryHandler
        /// </summary>
        /// <param name="context">Application db context</param>
        public GetSurveyDetailQueryHandler(IApplicationDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Handle the query
        /// </summary>
        /// <param name="request">request</param>
        /// <param name="cancellationToken">cancellation token</param>
        /// <returns>SurveyDetailModel </returns>
        public async Task<SurveyDetailModel> Handle(GetSurveyDetailQuery request, CancellationToken cancellationToken)
        {
         
            var entity = await _context.Surveys
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Surveys), request.Id);
            }

            if (!entity.isDeleted)
            {
                return SurveyDetailModel.Create(entity);
            }
            else
            {
                throw new NotFoundException(nameof(Surveys), request.Id);
            }
          
        }
    }
}
