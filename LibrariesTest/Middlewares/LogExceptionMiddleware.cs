using Microsoft.AspNetCore.Http;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace LibraryTest.NET.Middlewares
{
    public class LogExceptionMiddleware
    {
        private RequestDelegate _next;
        private static Logger _logger = LogManager.GetLogger("fileConfigRules");

        public LogExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong: {ex}");
                await HandleException(context);
            }
        }

        public Task HandleException(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            return context.Response.WriteAsync(context.Response.StatusCode.ToString());
        }
    }
}
