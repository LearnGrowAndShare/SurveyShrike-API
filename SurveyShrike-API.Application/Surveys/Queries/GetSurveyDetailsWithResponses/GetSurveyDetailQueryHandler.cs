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
namespace SurveyShrike_API.Application.Surveys.Queries.GetSurveyDetailsWithResponses
{
    public class GetSurveyDetailQueryHandler : IRequestHandler<GetSurveyDetailQuery, SurveyDetailModel>
    {
        private readonly IApplicationDBContext _context;
        private readonly IGetUserInformation _getUserInformation;
        public GetSurveyDetailQueryHandler(IApplicationDBContext context, IGetUserInformation getUserInformation)
        {
            _context = context;
            _getUserInformation = getUserInformation;
        }

        public async Task<SurveyDetailModel> Handle(GetSurveyDetailQuery request, CancellationToken cancellationToken)
        {
            var email = await _getUserInformation.GetUser();

            var entity = await _context.Surveys
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Surveys), request.Id);
            }

            if (entity.CreatedBy == email && !entity.isDeleted)
            {
                return SurveyDetailModel.Create(entity);
            }
            else {
                throw new NotFoundException(nameof(Surveys), request.Id);
            }
            
        }
    }
}
