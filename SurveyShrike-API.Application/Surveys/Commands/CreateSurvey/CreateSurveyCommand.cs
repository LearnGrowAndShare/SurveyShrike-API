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
namespace SurveyShrike_API.Application.Surveys.Commands.CreateSurvey
{

    public class CreateSurveyCommand : IRequest
    {
        public string Title { get; set; }
        public ICollection<FormFields> FormFields { get; set; }

        public class Handler : IRequestHandler<CreateSurveyCommand, Unit>
        {
            private readonly IApplicationDBContext _context;
            private readonly IMediator _mediator;
            private readonly IGetUserInformation _getUserInformation;
            public Handler(IApplicationDBContext context, IMediator mediator, IGetUserInformation getUserInformation)
            {
                _context = context;
                _mediator = mediator;
                _getUserInformation = getUserInformation;
            }

            public async Task<Unit> Handle(CreateSurveyCommand request, CancellationToken cancellationToken)
            {
                var email = await _getUserInformation.GetUser();
                var entity = new SurveyEntity.Survey
                {
                    Title = request.Title,
                    CreatedBy = email,
                    CreatedOn = DateTime.UtcNow,
                    ModifiedBy = email,
                    ModifiedOn = DateTime.UtcNow,
                    isDeleted = false
                };

                entity.SurveyForms = new List<SurveyEntity.SurveyFormField>();
                if (request.FormFields != null && request.FormFields.Count > 0) {
                    request.FormFields.ToList().ForEach(x =>
                    {
                        entity.SurveyForms.Add(new SurveyEntity.SurveyFormField()
                        {
                            FormConfiguration = x.FormConfiguration,
                            FormTypes = x.FormTypes,
                            Title = x.Title
                        });

                    });
                }

                _context.Surveys.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                await _mediator.Publish(new SurveyCreated(), cancellationToken);

                return Unit.Value;
            }
        }
    }
}
