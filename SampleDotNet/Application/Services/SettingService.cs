using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database;
using Microsoft.EntityFrameworkCore;
using SampleDotNet.Application.DTOs.Responses;
using SampleDotNet.Application.Interfaces;
using SampleDotNet.Common;
using StackExchange.Redis;

namespace SampleDotNet.Application.Services
{
    public class SettingService : ISettingService
    {
        private readonly DataContext _dataContext;
        private readonly IDatabase _redis;
        private readonly ILogger _logger;

        public SettingService(
            DataContext dataContext,
            IConnectionMultiplexer connectionMultiplexer,
            ILogger<SettingService> logger
        )
        {
            _dataContext = dataContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _redis = connectionMultiplexer.GetDatabase() ?? throw new ArgumentNullException(nameof(connectionMultiplexer));
        }

        public async Task<BaseResponse> syncRedisAsync()
        {
            // Clear key
            await _redis.KeyDeleteAsync(AuthEnum.USERNAME_LIST);

            var usernames = await _dataContext.Users.Select(_ => _.Username).ToListAsync();
            var countSuccessRecord = 0;

            foreach (var username in usernames)
            {
                var hashedUsername = Function.HashStringCRC32(username);

                _logger.LogInformation("Hashed {0} ===> {1}", username, hashedUsername);
                await _redis.StringSetBitAsync(AuthEnum.USERNAME_LIST, hashedUsername, true);
                countSuccessRecord++;
            }

            return new BaseResponse()
            {
                Data = new
                {
                    UsernameSync = countSuccessRecord,
                }
            };
        }
    }
}