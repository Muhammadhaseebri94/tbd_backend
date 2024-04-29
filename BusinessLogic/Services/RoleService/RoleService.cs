using Data_Access.Generic_Repository;
using Entities.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.RoleService
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly IGenericRepository<IdentityRole> _roleRepository;
        public RoleService(RoleManager<IdentityRole> roleManager, UserManager<User> userManager, IGenericRepository<IdentityRole> roleRepository)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _roleRepository = roleRepository;
        }
        public List<IdentityRole> GetAllRoles()
        {
            List<IdentityRole> rolesList = new List<IdentityRole>();
            try
            {
                rolesList = _roleManager.Roles.ToList();
                if(rolesList.Any())
                {
                    return rolesList;

                }
                return rolesList;
            }
            catch (Exception ex)
            {
                return rolesList;
            }

        }

        public object CreateRole(IdentityRole role)
        {
            try
            {
                if (role != null)
                {
                    var existingRole = _roleManager.FindByNameAsync(role.Name).Result;
                    if (existingRole != null)
                    {
                        return new { message = "Role already exists", status = 0, result = string.Empty };
                    }

                    var result = _roleManager.CreateAsync(role).Result;
                    if (result.Succeeded)
                    {
                        return new { message = "Role created successfully", status = 1, result = string.Empty };
                    }
                    else
                    {
                        return new { message = "Failed to create role", status = 0, result = string.Join(", ", result.Errors.Select(e => e.Description)) };
                    }
                }
                return new { message = "Role cannot be null", status = 0, result = string.Empty };
            }
            catch (Exception ex)
            {
                return new { message = ex.Message, result = string.Empty };
            }
        }
        public object DeleteRole(string roleId)
        {
            try
            {
                if (roleId != null)
                {
                    IdentityRole roleobj = _roleManager.FindByIdAsync(roleId).Result;
                    if (roleobj != null)
                    {
                        _roleManager.DeleteAsync(roleobj).Wait();
                        return new { message = "Role deleted successfully", result = string.Empty };
                    }
                    return new { message = "No role found against id", result = string.Empty };
                }
                return  new { message = "Role id can not be null", result = string.Empty };
            }
            catch (Exception ex)
            {
                return  new { message = ex.Message, result = string.Empty };
            }
        }
        public object UpdateRole(IdentityRole roleObj)
        {
            IdentityRole result = new IdentityRole();
            try
            {
                if (roleObj != null)
                {
                    _roleRepository.Update(roleObj);
                    _roleRepository.SaveChanges();
                    result = _roleRepository.Get(x => x.Id == roleObj.Id);
                    return new { message = "Role Updated Successfully", result };
                }
                return new { message = "Role can not be null", roleObj };
            }
            catch (Exception ex)
            {
                return  new { message = ex.Message, result };
            }
        }
        public IdentityRole GetRoleById(string roleId)
        {
            IdentityRole identityRole= new IdentityRole();
            try
            {
                if(roleId != null)
                {
                    identityRole = _roleRepository.Get(x => x.Id == roleId);
                    return identityRole;
                }
                return identityRole;
            }
            catch
            {
                return identityRole;
            }
        }
    }
}
