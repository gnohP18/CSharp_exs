using Microsoft.AspNetCore.Mvc;
using SampleDotNet.Application.Interfaces;

namespace SampleDotNet.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        [HttpGet("/check-exist")]
        public async Task<ActionResult<bool>> CheckExistUsername([FromQuery] string username)
        {
            return await _userService.CheckExistUsernameAsync(username);
        }
    }
}