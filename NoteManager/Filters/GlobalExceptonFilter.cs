using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using NoteManager.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NoteManager.Filters
{
    public class GlobalExceptonFilter : IExceptionFilter
    {
        private readonly ILogger<GlobalExceptonFilter> logger;

        public GlobalExceptonFilter(ILogger<GlobalExceptonFilter> logger)
        {
            this.logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            logger.LogError(context.Exception.Message);

            var result = new ObjectResult(new ErrorViewModel
            {
                ErrorMessage = context.Exception.Message,
                RequestId = Activity.Current?.Id ?? context.HttpContext.TraceIdentifier
            });
            result.StatusCode = 500;

            context.ExceptionHandled = true;
            context.Result = result;
        }
    }
}
