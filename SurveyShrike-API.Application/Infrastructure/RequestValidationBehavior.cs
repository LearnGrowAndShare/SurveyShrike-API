using FluentValidation;
using MediatR;
using SurveyShrike_API.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ValidationException = SurveyShrike_API.Application.Exceptions.ValidationException;

/// <summary>
/// @author Ankit
/// @date - 10/14/2019 3:57:40 PM 
/// </summary>
namespace SurveyShrike_API.Application.Infrastructure
{
    /// <summary>
    /// RequestValidationBehavior provides the validation for the aplication DTOs
    /// </summary>
    /// <typeparam name="TRequest">Type of Request</typeparam>
    /// <typeparam name="TResponse">Type of response</typeparam>
    public class RequestValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
         where TRequest : IRequest<TResponse>
    {
        /// <summary>
        /// validators defined for the request type.
        /// </summary>
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        /// <summary>
        /// Constructor for RequestValidationBehavior
        /// </summary>
        /// <param name="validators">List of all the validators</param>
        public RequestValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        /// <summary>
        /// Handle the validation 
        /// </summary>
        /// <param name="request">Request object</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <param name="next">next delegate objects</param>
        /// <returns></returns>
        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var context = new ValidationContext(request);

            var failures = _validators
                .Select(v => v.Validate(context))
                .SelectMany(result => result.Errors)
                .Where(f => f != null)
                .ToList();

            if (failures.Count != 0)
            {
                throw new ValidationException(failures);
            }

            return next();
        }
    }
}
