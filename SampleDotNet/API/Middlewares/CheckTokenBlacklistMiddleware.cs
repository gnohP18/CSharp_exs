using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using StackExchange.Redis;


namespace SampleDotNet.API.Middlewares
{
    public class CheckTokenBlacklistMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;
        private readonly IDatabase _redis;

        public CheckTokenBlacklistMiddleware(
            RequestDelegate next,
            IConfiguration configuration,
            IConnectionMultiplexer connectionMultiplexer)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _redis = connectionMultiplexer.GetDatabase();
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Implement Token blacklist

            await _next(context);
        }
    }
}