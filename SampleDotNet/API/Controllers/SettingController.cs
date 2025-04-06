using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SampleDotNet.API.Attributes;
using SampleDotNet.Application.DTOs.Responses;
using SampleDotNet.Application.Interfaces;

namespace SampleDotNet.API.Controllers
{
    [ApiController]
    [Tags("Setting")]
    [Route("api/settings")]
    public class SettingController : ControllerBase
    {
        private readonly ISettingService _settingService;

        public SettingController(ISettingService settingService)
        {
            _settingService = settingService ?? throw new ArgumentNullException(nameof(settingService));
        }

        [Authenticate]
        [HttpGet("sync-redis")]
        public async Task<ActionResult<BaseResponse>> SynRedis()
        {
            return await _settingService.syncRedisAsync();
        }
    }
}