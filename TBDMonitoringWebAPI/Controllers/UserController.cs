using BusinessLogic.Services.UserService;
using Entities.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Writers;

namespace TBDMonitoringWebAPI.Controllers
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
        [HttpPost]
        [Route("CreateUser")]
        public async Task<ActionResult> CreateUser(User user)
        {
            return Ok(await _userService.CreateUser(user));
        }
        [HttpPut]
        [Route("UpdateUser")]
        public async Task<ActionResult> UpdateUser(User user)
        {
            return Ok(await _userService.UpdateUser(user));
        }
        //[HttpGet]
        //[Route("GetUserRoles")]
        //public async Task< ActionResult> GetUserRoles(string useremail)
        //{
        //    if(useremail != null)
        //    {
        //        var result =await _userService.GetUserRoles(useremail);
        //        if (result!=null)
        //        {
        //            return Ok(result);
        //        }
        //        return NoContent();
        //    }
        //    return BadRequest("User Email Cannot Be Null");

        //}
        [HttpGet]
        [Route("GetUsers")]
        public IActionResult GetAllUsers()
        {
            return Ok(_userService.GetUsersList());
        }
        [HttpGet]
        [Route("GetUsersWithRoles")]
        public IActionResult GetUsersWithRoles()
        {
            return Ok(_userService.GetUsersWithRole());
        }
        [HttpGet]
        [Route("GetUserDetails/{userId}")]
        public async Task<IActionResult> GetUserDetails(string userId)
        {
            return Ok(await _userService.GetUserById(userId));
        }
        [HttpDelete]
        [Route("DeleteUser/{userId}")]
        public IActionResult DeleteUser(string userId)
        {
            return Ok(_userService.DeleteUser(userId));
        }
        [HttpGet]
        [Route("GetRolesByUserId/{userId}")]
        public ActionResult GetRolesByUserId(string userId)
        {
            return Ok(_userService.GetRolesByUserId(userId));
        }
    }
}
