using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.RoleService
{
    public interface IRoleService
    {
        public List<IdentityRole> GetAllRoles();
        public IdentityRole GetRoleById(string roleId);
        public object CreateRole(IdentityRole role);
        public object DeleteRole(string roleId);
        public object UpdateRole(IdentityRole roleObj);
    }
}
