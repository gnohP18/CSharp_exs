using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleDotNet.Application.Exceptions;

namespace SampleDotNet.API.Middlewares
{
    public class CheckUserAgentMiddleware
    {
        private readonly RequestDelegate _next;

        public CheckUserAgentMiddleware(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue("User-Agent", out var userAgent))
            {
                throw new BadRequestException($"Missing User-Agent in Header");
            }

            await _next(context);
        }
    }
}