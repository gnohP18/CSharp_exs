using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleDotNet.Application.DTOs.Responses
{
    public class RefreshResponse
    {
        public string RefreshToken { get; set; } = null!;
        public string Token { get; set; } = null!;
    }
}