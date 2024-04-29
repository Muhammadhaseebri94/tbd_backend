using BusinessLogic.Services.RoleService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TBDMonitoringWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleservice;
        public RolesController(IRoleService roleservice)
        {
            _roleservice = roleservice;
        }
        [HttpGet]
        [Route("GetAllRoles")]
        public ActionResult GetAllRoles()
        {
            return Ok(_roleservice.GetAllRoles());
        }
        [HttpGet]
        [Route("GetRoleById/{userId}")]
        public ActionResult GetRoleById(string userId)
        {
            return Ok(_roleservice.GetRoleById(userId));
        }
        [HttpPost]
        [Route("CreateRole")]
        public ActionResult CreateRole(IdentityRole role)
        {
            return Ok(_roleservice.CreateRole(role));
        }
        [HttpPut]
        [Route("UpdateRole")]
        public ActionResult DeleteRole(IdentityRole roleObj)
        {
            return Ok(_roleservice.UpdateRole(roleObj));
        }
        [HttpDelete]
        [Route("DeleteRole/{roleId}")]
        public ActionResult DeleteRole(string roleId) 
        {
            return Ok(_roleservice.DeleteRole(roleId));
        }
    }
}
