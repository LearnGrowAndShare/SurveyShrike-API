using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

/// <summary>
/// @author Ankit
/// @date - 10/14/2019 3:57:25 PM 
/// </summary>
namespace SurveyShrike_API.Application.Infrastructure
{
    /// <summary>
    /// Logs the request and response of the object.
    /// </summary>
    /// <typeparam name="TRequest">Type of Request recieved.</typeparam>
    /// <typeparam name="TResponse">Type of Response sent.</typeparam>
    public class RequestPerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly Stopwatch _timer;
        private readonly ILogger<TRequest> _logger;

        /// <summary>
        /// Constructor for RequestPerformanceBehaviour
        /// </summary>
        /// <param name="logger">Instance of logged to log.</param>
        public RequestPerformanceBehaviour(ILogger<TRequest> logger)
        {
            _timer = new Stopwatch();

            _logger = logger;
        }

        /// <summary>
        /// Handle method perform the actual
        /// </summary>
        /// <param name="request">Request object</param>
        /// <param name="cancellationToken">Cancellation token </param>
        /// <param name="next">the next operation to perofrm</param>
        /// <returns></returns>
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            _timer.Start();

            var response = await next();

            _timer.Stop();

            if (_timer.ElapsedMilliseconds > 500)
            {
                var name = typeof(TRequest).Name;

                // TODO: Add User Details

                _logger.LogWarning("Northwind Long Running Request: {Name} ({ElapsedMilliseconds} milliseconds) {@Request}", name, _timer.ElapsedMilliseconds, request);
            }

            return response;
        }
    }
}
