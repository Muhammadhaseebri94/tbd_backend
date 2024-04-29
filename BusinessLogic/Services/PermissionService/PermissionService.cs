using Data_Access.Generic_Repository;
using Entities.DTOs;
using Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.PermissionService
{
    public class PermissionService : IPermissionService
    {
        private readonly IGenericRepository<Permission> _permissionRepository;
        private readonly IGenericRepository<RolePermission> _rolePermissionRepository;
        public PermissionService(IGenericRepository<Permission> permissionRepository, IGenericRepository<RolePermission> rolePermissionRepository)
        {
            _permissionRepository = permissionRepository;
            _rolePermissionRepository = rolePermissionRepository;
        }
        public string CreatePermission(Permission permission)
        {
            try
            {
                if (permission != null)
                {
                    _permissionRepository.Add(permission);
                    _permissionRepository.SaveChanges();
                    return "Permission Added Successfully";
                }
                return "Permission can not be Null";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string DeletePermission(int permissionId)
        {
            try
            {
                if (permissionId != null)
                {
                    Permission permission = _permissionRepository.Get(x => x.Id == permissionId);
                    _permissionRepository.Remove(permission);
                    return "Permission Deleted Successfully";
                }
                return "Permission Id can not be null";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<Permission> GetAllPermissions()
        {
            List<Permission> permissionslist = new List<Permission>();
            try
            {
                permissionslist = _permissionRepository.GetAll(null).ToList();
                return permissionslist;
            }
            catch (Exception ex)
            {
                return permissionslist;
            }
        }

        public Permission GetPermissionById(int permissionId)
        {
            Permission permission = new Permission();
            try
            {
                permission = _permissionRepository.Get(x => x.Id == permissionId);
                return permission;
            }
            catch
            {
                return permission;
            }
        }
        public List<Permission> GetPermissionsByRoleId(string roleId)
        {
            List<Permission> permissionsList = new List<Permission>();
            try
            {
                if (roleId != null)
                {
                    List<RolePermission> rolePermissionsList = _rolePermissionRepository.GetAll(x => x.RoleId == roleId).ToList();
                    foreach (var rolepermission in rolePermissionsList)
                    {
                        permissionsList.Add(_permissionRepository.Get(x => x.Id == rolepermission.PermissionId));
                    }
                    return permissionsList;

                }
                return permissionsList;
            }
            catch
            {
                return permissionsList;
            }
        }
        public string UpdatePermissionsForRole(PermissionsToRole permissionstoroleobj)
        {
            List<RolePermission> rolePermissionsList = new List<RolePermission>();
            try
            {
                List<RolePermission> rolePermissionsListFromDB = _rolePermissionRepository.GetAll(x => x.RoleId == permissionstoroleobj.RoleId).ToList();
                if (rolePermissionsListFromDB != null)
                {
                    _rolePermissionRepository.RemoveRange(rolePermissionsListFromDB);
                    _rolePermissionRepository.SaveChanges();
                }
                if (permissionstoroleobj != null)
                {
                    foreach (var permission in permissionstoroleobj.PermissionIds)
                    {
                        RolePermission permissionToSet = new RolePermission
                        {
                            RoleId =permissionstoroleobj.RoleId,
                            PermissionId=permission
                        };
                        _rolePermissionRepository.Add(permissionToSet);
                        _rolePermissionRepository.SaveChanges();
                        return "Permissions Updated Successfully";
                    }
                }
                return "Null Permissions to Role Object Recieved";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public object UpdatePermission(Permission permission)
        {
            try
            {
                if (permission != null)
                {
                    _permissionRepository.Update(permission);
                    _permissionRepository.SaveChanges();
                    Permission permissionobj = _permissionRepository.Get(x=>x.Id==permission.Id);

                    return new { result = "Permission Updated Successfully", permissionobj };
                }
                return "Error in Updating Permission";
            }
            catch (Exception ex) 
            {
                return ex.Message;
            }
        }
    }
}
