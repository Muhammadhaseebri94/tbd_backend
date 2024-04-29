using Business_Logic.Services.Authentication;
using BusinessLogic.Services.UserService;
using Entities.DTOs;
using Entities.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TBD_Monitoring_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserService _userService;
        private readonly IConfiguration _config;

        public AuthenticationController(IAuthenticationService authservice,IUserService userService, IConfiguration config)
        {
            _authenticationService = authservice;
            _userService = userService;
            _config = config;
        }
        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult> Login([FromBody] LoginModel model)
        {
            var result =await _authenticationService.Login(model,_config.GetSection("Jwt:Key").Value);
            return Ok(result);
        }


    }
}
