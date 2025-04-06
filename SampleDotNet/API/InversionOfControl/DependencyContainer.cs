using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleDotNet.Application.Interfaces;
using SampleDotNet.Application.Services;
using static SampleDotNet.API.Attributes.AuthenticateAttribute;

namespace SampleDotNet.API.InversionOfControl
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<ITokenService, TokenService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ISettingService, SettingService>();

            services.AddScoped<IAuthenticationFilterService, AuthenticationFilterService>();
        }
    }
}