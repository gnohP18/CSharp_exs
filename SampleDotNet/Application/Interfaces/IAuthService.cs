using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleDotNet.Application.DTOs.Requests;
using SampleDotNet.Application.DTOs.Responses;

namespace SampleDotNet.Application.Interfaces
{
    public interface IAuthService
    {
        /// <summary>
        /// Login user
        /// </summary>
        /// <param name="request">Request from user of tenant</param>
        /// <returns>LoginResponse</returns>
        Task<SignInResponse> LoginAsync(SignInRequest request);

        /// <summary>
        /// Logout user
        /// </summary>
        /// <returns>BaseResponse</returns>
        Task<BaseResponse> LogoutAsync();

        /// <summary>
        /// Refresh login and generate access token, refresh token again
        /// </summary>
        /// <param name="request">RefreshLoginRequest</param>
        /// <returns>BaseResponse</returns>
        Task<SignInResponse> RefreshLoginAsync(RefreshLoginRequest request);
    }
}