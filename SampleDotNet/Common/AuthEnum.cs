using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace SampleDotNet.Common
{
    public static class AuthEnum
    {
        public static RedisKey ACCESS_TOKEN_BLACK_LIST = "AUTH:access_token_black_list";
        public static RedisKey REFRESH_TOKEN_BLACK_LIST = "AUTH:refresh_token_black_list";
        public static RedisKey USERNAME_LIST = "USER:username";
        public static int BONUS_HOUR_REFRESH_TOKEN = 48;
    }
}