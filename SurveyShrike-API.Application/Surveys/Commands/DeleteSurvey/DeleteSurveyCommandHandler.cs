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

        public DeleteSurveyCommandHandler(IApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteSurveyCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Surveys
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Survey), request.Id);
            }


            entity.isDeleted = true;
           

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
