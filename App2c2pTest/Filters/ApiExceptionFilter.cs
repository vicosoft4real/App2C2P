using System;
using System.Threading.Tasks;
using App2c2pTest.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace App2c2pTest.Filters
{
    public class ApiExceptionFilter: ExceptionFilterAttribute
    {
        private readonly ILogger<ApiExceptionFilter> _logger;

        public ApiExceptionFilter(ILogger<ApiExceptionFilter> logger)
        {
            _logger = logger;
        }

        public override void OnException(ExceptionContext context)
        {
            if (!context.ExceptionHandled)
            {
                if (context.Exception is ApplicationException)
                {
                    context.Result = new BadRequestObjectResult(new CardResponse { CardType = "Unknown", Result = "Invalid" });
                }
                else
                {
                    context.Result = new BadRequestObjectResult(new CardResponse { CardType = "Unknown", Result = "Invalid" });
                }
                _logger.LogError(new EventId(), context.Exception, context.Exception.Message);
                context.ExceptionHandled = true;
            }
            base.OnException(context);
        }

        public override Task OnExceptionAsync(ExceptionContext context)
        {
            if (!context.ExceptionHandled)
            {
                if (context.Exception is ApplicationException)
                {
                    context.Result = new BadRequestObjectResult(new CardResponse { CardType = "Unknown", Result = "Invalid" });
                }
                else
                {
                    context.Result = new BadRequestObjectResult(new CardResponse { CardType = "Unknown", Result = "Invalid" });
                }

                _logger.LogError(new EventId(), context.Exception, context.Exception.Message);
                context.ExceptionHandled = true;
            }
            return base.OnExceptionAsync(context);
        }
    }
}
