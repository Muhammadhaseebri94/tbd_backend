using Entities.DTOs;
using Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.PermissionService
{
    public interface IPermissionService
    {
        public List<Permission> GetAllPermissions();
        public Permission GetPermissionById(int permissionId);
        public List<Permission> GetPermissionsByRoleId(string roleId);
        public string CreatePermission(Permission permission);
        public string DeletePermission(int  permissionId);
        public string UpdatePermissionsForRole(PermissionsToRole permissionstoroleobj);
        public object UpdatePermission(Permission permission);
    }
}
