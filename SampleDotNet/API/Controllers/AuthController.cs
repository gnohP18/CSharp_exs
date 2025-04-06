using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SampleDotNet.API.Attributes;
using SampleDotNet.Application.DTOs.Requests;
using SampleDotNet.Application.DTOs.Responses;
using SampleDotNet.Application.Interfaces;

namespace SampleDotNet.API.Controllers
{
    [ApiController]
    [Tags("Authentication")]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
        }

        [HttpPost("login")]
        public async Task<ActionResult<BaseResponse>> Login([FromBody] SignInRequest request)
        {
            return await _authService.LoginAsync(request);
        }

        [Authenticate]
        [HttpPost("logout")]
        public async Task<ActionResult<BaseResponse>> Logout()
        {
            return await _authService.LogoutAsync();
        }

        [HttpPost("refresh")]
        public async Task<ActionResult<SignInResponse>> RefreshLogin([FromBody] RefreshLoginRequest request)
        {
            return await _authService.RefreshLoginAsync(request);
        }
    }
}