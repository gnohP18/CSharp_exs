using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleDotNet.Application.Interfaces;
using SampleDotNet.Common;
using StackExchange.Redis;

namespace SampleDotNet.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IDatabase _redis;

        public UserService(IConnectionMultiplexer connectionMultiplexer)
        {
            _redis = connectionMultiplexer.GetDatabase() ?? throw new ArgumentNullException(nameof(connectionMultiplexer));
        }

        public async Task<bool> CheckExistUsernameAsync(string username)
        {
            var usernameHashed = Function.HashStringCRC32(username);

            if (!await _redis.StringGetBitAsync(AuthEnum.USERNAME_LIST, usernameHashed))
            {
                return false;
            }
            ;

            return true;
        }
    }
}