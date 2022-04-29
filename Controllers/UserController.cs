using CRUD_WEB_API.DTO;
using CRUD_WEB_API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using CRUD_WEB_API.Helpers;

namespace CRUD_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect!" });

            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserDTO userModel)
        {
            var response = await _userService.Register(userModel);

            if (!response)
            {
                return BadRequest(new { message = "This user does exist." });
            }

            return Ok("User has been created.");
        }

        [HttpPost("RegisterToMeetUp")]
        public async Task<IActionResult> RegisterToMeetUp(string token, int meetupId)
        {
            var userId = UserHelper.GetIdClaimFromToken(token);
            if (userId is null)
            {
                return BadRequest(new { message = "Authorization failed." });
            }

             var response = await _userService.RegisterToMeetUp(int.Parse(userId), meetupId);

            return Ok(response);
        }
    }
}