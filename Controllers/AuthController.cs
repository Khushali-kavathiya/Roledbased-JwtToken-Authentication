using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using JwtRoleBased.Entities;
using JwtRoleBased.Model;
using JwtRoleBased.Interface;

namespace JwtRoleBased.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuth service;
        public AuthController(IAuth service)
        {
            this.service = service;
        }


        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDto request)
        {
            var User = await service.Register(request);
            if (User == null)
            {
                return BadRequest("User already exists");
            }
            return Ok(User);
        }


        [HttpPost("login")]
        public async Task<ActionResult<TokenResponseDto>> Login(UserDto request)
        {
            var token = await service.Login(request);
            if (token is null)
                return BadRequest("Invalid credentials");
            return Ok(token);
        }

        [HttpPost("referesh-token")]
        public async Task<ActionResult<TokenResponseDto>> RefreshToken(RefreshTokenRequestDto request)
        {
            var token = await service.RefreshTokenAsync(request);
            if (token is null)
                return BadRequest("Invalid/expired refresh token");
            return Ok(token);
        }
       

        [HttpGet("Auth-endpoint")]
        [Authorize]
        public ActionResult AuthCkeck()
        {
            return Ok();
        }

        [HttpGet("Admin-endpoint")]
        [Authorize(Roles = "Admin")]
        public ActionResult AdminCheck()
        {
            return Ok("You are an admin");
        }

    }

}