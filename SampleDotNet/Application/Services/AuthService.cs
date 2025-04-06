using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using Database;
using Google.Protobuf;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using SampleDotNet.Application.DTOs.Requests;
using SampleDotNet.Application.DTOs.Responses;
using SampleDotNet.Application.Exceptions;
using SampleDotNet.Application.Interfaces;
using SampleDotNet.Common;
using StackExchange.Redis;

namespace SampleDotNet.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly ITokenService _tokenService;
        private readonly DataContext _dataContext;
        private readonly IDatabase _redis;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger _logger;

        public AuthService(
            ITokenService tokenService,
            DataContext dataContext,
            IConnectionMultiplexer connectionMultiplexer,
            ILogger<AuthService> logger,
            IHttpContextAccessor httpContextAccessor)
        {
            _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
            _dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _redis = connectionMultiplexer.GetDatabase() ?? throw new ArgumentNullException(nameof(connectionMultiplexer));
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        public async Task<SignInResponse> LoginAsync(SignInRequest request)
        {
            _logger.LogInformation("Start LoginAsync");
            // Check request
            var user = await _dataContext.Users.FirstOrDefaultAsync(x => x.Username == request.Username);
            if (user is null)
            {
                throw new NotFoundException("Not found user");
            }

            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
            {
                throw new BadRequestException("Wrong Password");
            }

            var jti = Guid.NewGuid().ToString();

            var accessToken = _tokenService.GenerateToken(user, jti);

            var refreshToken = _tokenService.GenerateRefreshToken(user, jti);

            _logger.LogInformation("End LoginAsync");

            return new SignInResponse()
            {
                Message = "Sign in successfully",
                Data = new
                {
                    AccessToken = accessToken,
                    RefreshToken = refreshToken
                }
            };
        }

        public async Task<BaseResponse> LogoutAsync()
        {
            _httpContextAccessor.HttpContext.Request.Headers.TryGetValue("Authorization-UserId", out var userId);
            _httpContextAccessor.HttpContext.Request.Headers.TryGetValue("Authorization-Jti", out var jti);

            var key = $"{AuthEnum.ACCESS_TOKEN_BLACK_LIST}_{jti}_{userId}";

            // Revoke token
            await _redis.StringSetAsync(key, 1);

            return new BaseResponse()
            {
                Message = "Token revoked",
            };


        }

        public async Task<SignInResponse> RefreshLoginAsync(RefreshLoginRequest request)
        {
            // Ý tưởng
            // 1. Lấy claim từ refresh token
            // 2. Kiểm tra xem trong redis có tồn tại jti không
            // 3. Nếu có throw exception, thông báo mail, .v.v
            // 4. Nếu không add jti vào trong redis và cấp access token, refresh token mới 

            // 1. Lấy claim từ refresh token
            var claim = _tokenService.ValidateToken(request.RefreshToken);

            if (claim == null)
            {
                throw new UnAuthorizedException("Invalid Refresh Token");
            }

            var userId = claim.FindFirstValue("userId");

            var user = await _dataContext.Users.FirstOrDefaultAsync(_ => _.Id == Int32.Parse(userId));
            if (user == null)
            {
                throw new NotFoundException("User not found");
            }

            var jti = claim.FindFirstValue(JwtRegisteredClaimNames.Jti);

            // 2. Kiểm tra xem trong redis có tồn tại jti không
            if (await _redis.KeyExistsAsync($"{AuthEnum.REFRESH_TOKEN_BLACK_LIST}_{jti}_{userId}"))
            {
                // 3. Nếu có throw exception, thông báo mail, .v.v
                throw new UnAuthorizedException("Refresh token is expired, please login again");
            }

            // 4. Nếu không add jti vào trong redis và cấp access token, refresh token mới 
            var key = $"{AuthEnum.REFRESH_TOKEN_BLACK_LIST}_{jti}_{userId}";
            // 4.1 Revoke refresh token
            await _redis.StringSetAsync(key, 1);

            var newJti = Guid.NewGuid().ToString();

            var accessToken = _tokenService.GenerateToken(user, newJti);

            var refreshToken = _tokenService.GenerateRefreshToken(user, newJti);

            return new SignInResponse()
            {
                Message = "Generate access token successfully",
                Data = new
                {
                    AccessToken = accessToken,
                    RefreshToken = refreshToken
                }
            };
        }
    }
}