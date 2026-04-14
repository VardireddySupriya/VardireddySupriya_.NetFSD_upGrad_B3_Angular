using backend_mini_project1.Models;
using backend_mini_project1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend_mini_project1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;

        public AuthController(IAuthService service)
        {
            _service = service;
        }

        //  REGISTER
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var user = await _service.RegisterAsync(dto);
                return Ok(new
                {
                    data = new
                    {
                        user.UserId,
                        user.Name,
                        user.Email,
                        user.Role,
                        user.CreatedAt
                    }
                });
            }



            catch (ApplicationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        //  LOGIN 
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _service.LoginAsync(dto);

                return Ok(new
                {
                    message = "Login successfully",
                    data = result
                });
            }
            catch (ApplicationException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
        }

    }
}
