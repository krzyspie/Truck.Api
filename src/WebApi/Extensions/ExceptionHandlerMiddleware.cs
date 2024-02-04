using Application.Common;
using Domain.Exceptions;
using FluentValidation;

namespace WebApi.Extensions
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _request;

        public ExceptionHandlerMiddleware(RequestDelegate request)
        {
            _request = request;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _request(context);
            }
            catch (ValidationException exception)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                var messages = exception.Errors.Select(x => x.ErrorMessage).ToList();
                var validationFailureResponse = new ValidationFailureResponse
                {
                    Errors = messages
                };
                await context.Response.WriteAsJsonAsync(validationFailureResponse);
            }
            catch (TruckNotFoundException exception)
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                await context.Response.WriteAsJsonAsync(new {
                    Error = exception.Message,
                    ExceptionStackTrace = exception.StackTrace
                });
            }
            catch (Exception exception)
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsJsonAsync(new
                {
                    Error = exception.Message,
                    ExceptionStackTrace = exception.StackTrace
                });
            }
        }
    }
}
