using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace SimpleWebApi.Web.Middleware
{
    public class GlobalExceptionFilter : IExceptionFilter
    {

        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            context.HttpContext.Response.StatusCode = 500;

            context.Result = new ObjectResult(new
            {
                error = "An exception has occured.",
                message = exception.Message
            })
            {
                StatusCode = context.HttpContext.Response.StatusCode
            };

            context.ExceptionHandled = true;
        }
    }
}
