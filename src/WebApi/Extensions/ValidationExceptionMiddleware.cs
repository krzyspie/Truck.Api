using Application.Common;
using FluentValidation;

namespace WebApi.Extensions
{
    public class ValidationExceptionMiddleware
    {
        private readonly RequestDelegate _request;

        public ValidationExceptionMiddleware(RequestDelegate request)
        {
            _request = request;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _request(context);
            }
            catch (Exception exception)
            {
                var valisationEx = exception.InnerException as ValidationException;
                if (valisationEx != null)
                {
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    var messages = valisationEx.Errors.Select(x => x.ErrorMessage).ToList();
                    var validationFailureResponse = new ValidationFailureResponse
                    {
                        Errors = messages
                    };
                    await context.Response.WriteAsJsonAsync(validationFailureResponse);
                }
            }
        }
    }
}
