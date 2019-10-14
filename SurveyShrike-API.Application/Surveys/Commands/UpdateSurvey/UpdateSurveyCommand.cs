using MediatR;
using Microsoft.EntityFrameworkCore;
using SurveyShrike_API.Application.Exceptions;
using SurveyShrike_API.Application.Interfaces;
using SurveyShrike_API.Application.Surveys.Commands.CreateSurvey;
using SurveyShrike_API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// @author Ankit
/// @date - 10/14/2019 4:27:13 PM 
/// </summary>
namespace SurveyShrike_API.Application.Surveys.Commands.UpdateSurvey
{
    public class UpdateSurveyCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
       
        public ICollection<FormFields> FormFields { get; set; }

        public class Handler : IRequestHandler<UpdateSurveyCommand, Unit>
        {
            private readonly IApplicationDBContext _context;
            private readonly IGetUserInformation _getUserInformation;
            public Handler(IApplicationDBContext context, IGetUserInformation getUserInformation)
            {
                _context = context;
                _getUserInformation = getUserInformation;
            }

            public async Task<Unit> Handle(UpdateSurveyCommand request, CancellationToken cancellationToken)
            {
                var email = await _getUserInformation.GetUser();
                var entity = await _context.Surveys
                    .SingleOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Survey), request.Id);
                }

                if (entity.CreatedBy != email || entity.isDeleted)
                {
                    throw new NotFoundException(nameof(Survey), request.Id);
                }

                entity.Title = request.Title;
               
                if (request.FormFields != null && request.FormFields.Count > 0)
                {
                    if (entity.SurveyForms == null) {
                        entity.SurveyForms = new List<SurveyFormField>();
                    }
                    request.FormFields.ToList().ForEach(x =>
                    {
                        entity.SurveyForms.Add(new SurveyFormField()
                        {
                            FormConfiguration = x.FormConfiguration,
                            FormTypes = x.FormTypes,
                            Title = x.Title
                        });

                    });
                }

                entity.ModifiedBy = email;
                entity.ModifiedOn = DateTime.UtcNow;
                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
