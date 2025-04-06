using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using SampleDotNet.Application.DTOs.Requests;
using SampleDotNet.Application.DTOs.Responses;
using SampleDotNet.Database.Models;

namespace SampleDotNet.Application.Interfaces
{
    public interface ITokenService
    {
        /// <summary>
        /// Generate token => Claim Id, Email
        /// Expire time : 1 day
        /// </summary>
        /// <param name="user">User Login/Register</param>
        /// <returns>string</returns>
        string GenerateToken(User user, string jti);

        /// <summary>
        /// Validate token => Basic validation handle
        /// </summary>
        /// <param name="token">token from HTTP request</param>
        /// <returns>ClaimsPrincipal</returns>
        ClaimsPrincipal? ValidateToken(string token);

        /// <summary>
        /// Generate Refresh token
        /// </summary>
        /// <param name="token">Token expired</param>
        /// <param name="refreshToken">Refresh token</param>
        /// <returns>Token</returns>
        string GenerateRefreshToken(User user, string jti);
    }
}