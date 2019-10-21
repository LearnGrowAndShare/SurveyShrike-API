using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// @author Ankit
/// @date - 10/14/2019 3:57:03 PM 
/// </summary>
namespace SurveyShrike_API.Application.Infrastructure
{
    /// <summary>
    /// Logs each request
    /// </summary>
    /// <typeparam name="TRequest">Type of the Http request.</typeparam>
    public class RequestLogger<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly ILogger _logger;

        public RequestLogger(ILogger<TRequest> logger)
        {
            _logger = logger;
        }

        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var name = typeof(TRequest).Name;

            // TODO: Add User Details

            _logger.LogInformation("Request: {Name} {@Request}", name, request);

            return Task.CompletedTask;
        }
    }
}
