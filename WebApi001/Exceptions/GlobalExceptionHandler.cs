using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
namespace WebApi001.Exceptions

{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception,CancellationToken cancellationToken)
        {
            _logger.LogError(exception, "An unhandled exception occurred.");

            var StatusCode = exception switch
            {
                ArgumentNullException => StatusCodes.Status400BadRequest,                        
                KeyNotFoundException => StatusCodes.Status404NotFound,
                UnauthorizedAccessException => StatusCodes.Status401Unauthorized,
                _ => StatusCodes.Status500InternalServerError
            };                 

            var problemDetails = new ProblemDetails
            {
                Status = StatusCode,
                Title = StatusCode switch
                {
                    400 => "Bad Request",
                    404 => "Not Found",
                    401 => "Unauthorized",
                    _ => "Internal Server Error"
                },

                Detail = StatusCode== 500
                ? "An Server Error occurred."
                : exception.Message,
                Instance = httpContext.Request.Path.Value


            };

            httpContext.Response.StatusCode = StatusCode;

            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);
            return true;
        }

    }
}
