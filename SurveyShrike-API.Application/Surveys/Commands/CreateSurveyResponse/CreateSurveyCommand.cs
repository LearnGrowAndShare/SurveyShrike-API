using MediatR;
using SurveyShrike_API.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SurveyEntity = SurveyShrike_API.Domain.Entities;
/// <summary>
/// @author Ankit
/// @date - 10/14/2019 4:04:20 PM 
/// </summary>
namespace SurveyShrike_API.Application.Surveys.Commands.CreateSurveyResponse
{

    public class CreateSurveyCommand : IRequest
    {
        public string IP { get; set; }
        public ICollection<FormReponse> FormFields { get; set; }

        public class Handler : IRequestHandler<CreateSurveyCommand, Unit>
        {
            private readonly IApplicationDBContext _context;
            private readonly IMediator _mediator;
            
            public Handler(IApplicationDBContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
   
            }

            public async Task<Unit> Handle(CreateSurveyCommand request, CancellationToken cancellationToken)
            {
                var entity = new List<SurveyEntity.SurveyResponse>();
                
                request.FormFields.ToList().ForEach(async x =>
                {
                    var surveyFormField = await _context.SurveyFormFields.FindAsync(x.FormId);
                    if (surveyFormField != null)
                    {
                        entity.Add(new SurveyEntity.SurveyResponse
                        {
                            Response = x.Response,
                            ReportedIP = request.IP,
                            ReportedAt = DateTime.UtcNow,
                            SurveyFormField = surveyFormField
                        });
                     }
                });
             

                _context.SurveyResponses.AddRange(entity);

                await _context.SaveChangesAsync(cancellationToken);

                await _mediator.Publish(new SurveyCreated(), cancellationToken);

                return Unit.Value;
            }
        }
    }
}
