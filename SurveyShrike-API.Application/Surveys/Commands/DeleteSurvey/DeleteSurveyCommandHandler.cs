using MediatR;
using SurveyShrike_API.Application.Exceptions;
using SurveyShrike_API.Application.Interfaces;
using SurveyShrike_API.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// @author Ankit
/// @date - 10/14/2019 4:24:32 PM 
/// </summary>
namespace SurveyShrike_API.Application.Surveys.Commands.DeleteSurvey
{
     public class DeleteSurveyCommandHandler : IRequestHandler<DeleteSurveyCommand>
    {
        private readonly IApplicationDBContext _context;
        private readonly IGetUserInformation _getUserInformation;

        public DeleteSurveyCommandHandler(IApplicationDBContext context, IGetUserInformation getUserInformation)
        {
            _context = context;
            _getUserInformation = getUserInformation;
        }

        public async Task<Unit> Handle(DeleteSurveyCommand request, CancellationToken cancellationToken)
        {
            var email = await _getUserInformation.GetUser();

            var entity = await _context.Surveys
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Survey), request.Id);
            }

            if (entity.CreatedBy != email || entity.isDeleted)
            {
                throw new NotFoundException(nameof(Survey), request.Id);
            }


            entity.isDeleted = true;
            entity.ModifiedBy = email;
            entity.ModifiedOn = System.DateTime.UtcNow;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
