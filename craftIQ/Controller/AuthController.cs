using CraftIQ.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CraftIQ.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authservice;

        public AuthController(IAuthService authservice)
        {
            this.authservice = authservice;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {          
            if(!ModelState.IsValid) 
                BadRequest(ModelState);

            var result = await authservice.Register(model);
            if(!result.IsAuthentecated)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
                BadRequest(ModelState);

            var result = await authservice.GetToken(model);
            if (!result.IsAuthentecated)
                return BadRequest(result.Message);

            return Ok(result);
        }

    }
}
