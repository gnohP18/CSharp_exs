using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleDotNet.Application.DTOs.Responses;

namespace SampleDotNet.Application.Interfaces
{
    public interface ISettingService
    {
        /// <summary>
        /// Synchronize Redis
        /// </summary>
        /// <returns>BaseResponse</returns>
        Task<BaseResponse> syncRedisAsync();
    }
}