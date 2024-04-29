using BusinessLogic.Services.PermissionService;
using Entities.DTOs;
using Entities.Entity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TBDMonitoringWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionsController : ControllerBase
    {
        private readonly IPermissionService _permissionService;
        public PermissionsController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }
        [HttpGet]
        [Route("GetAllPermissions")]
        public IActionResult GetAllPermissions()
        {
            return Ok(_permissionService.GetAllPermissions());
        }
        [HttpGet]
        [Route("GetPermissionById/{permissionId}")]
        public IActionResult GetPermissionById(int permissionId)
        {
            return Ok(_permissionService.GetPermissionById(permissionId));
        }
        [HttpGet("GetPermissionByRoleId/{roleId}")]
        public IActionResult GetPermissionByRoleId(string roleId)
        {
            return Ok(_permissionService.GetPermissionsByRoleId(roleId));
        }
        [HttpPost]
        [Route("CreatePermission")]
        public IActionResult CreatePermission(Permission permission)
        {
            return Ok(_permissionService.CreatePermission(permission));
        }
        [HttpPut]
        [Route("UpdatePermission")]
        public IActionResult UpdatePermission(Permission permission) 
        {
            return Ok(_permissionService.UpdatePermission(permission));
        }
        [HttpDelete("DeletePermission/{permissionId}")]
        public IActionResult DeletePermission(int permissionId)
        {
            return Ok(_permissionService.DeletePermission(permissionId));
        }
        [HttpPost]
        [Route("UpdatePermissionsForRole")]
        public IActionResult UpdatePermissionsForRole(PermissionsToRole permissionstorole) 
        {
            return Ok(_permissionService.UpdatePermissionsForRole(permissionstorole));
        }
    }
}
