using Data_Access.Context;
using Data_Access.Generic_Repository;
using Entities.DTOs;
using Entities.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IGenericRepository<User> _userRepository;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _context;
        private readonly IGenericRepository<IdentityRole> _roleRepository;
        public UserService(UserManager<User> userManager, SignInManager<User> signinManager, RoleManager<IdentityRole> roleManager,IGenericRepository<User> userrepository, IGenericRepository<IdentityRole> roleRepository)
        {
            _userManager = userManager;
            _signInManager = signinManager;
            _roleManager = roleManager;
            _userRepository = userrepository;
            _roleRepository = roleRepository;
        }
        public async Task<List<string>> GetUserRoles(string email)
        {
            if (email != null)
            {
                User user = await _userManager.FindByEmailAsync(email);
                if (user != null)
                {
                    var roles = await _userManager.GetRolesAsync(user);
                    return (List<string>)roles;
                }
            }
            return null;
        }
        public async Task<object> CreateUser(User user)
        {
            try
            {
                if (user != null)
                {
                   var userData = await _userManager.FindByEmailAsync(user.Email);
                    if (userData != null)
                    {
                        return new { status = 0, message = "Email already exists" };
                    }
                    user.UserName = user.Email;
                    user.EmailConfirmed = true;
                    user.LockoutEnabled = false;
                    var result = await _userManager.CreateAsync(user,user.PasswordHash);
                    if (result.Succeeded)
                    {
                        foreach(var role in user.Roles)
                        {
                            var roleObj = _roleRepository.Get(x => x.Id == role.RoleId);
                           await _userManager.AddToRoleAsync(user, roleObj.Name);
                        }
                        return new { status = 1, message = "User Created Successfully" };

                    }
                    return null;
                }
                return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
        public async Task<object> UpdateUser(User user)
        {
            try
            {
                if (user.Id != null)
                {
                    var existingUser = _userRepository.Get(x => x.Id == user.Id);

                    if (existingUser != null)
                    {
                        existingUser.Name = user.Name;
                        existingUser.Address = user.Address;
                        existingUser.PECNumber = user.PECNumber;
                        existingUser.PhoneNumber = user.PhoneNumber;
                        existingUser.EmergencyPhoneNumber = user.EmergencyPhoneNumber;
                        existingUser.BloodGroup = user.BloodGroup;
                        existingUser.CNIC = user.CNIC;
                        existingUser.DOJ = user.DOJ;
                        existingUser.Abbreviation = user.Abbreviation;
                        existingUser.Picture = user.Picture;

                        if(!string.IsNullOrEmpty(user.PasswordHash))
                        {

                            var newHashedPwd = _userManager.PasswordHasher.HashPassword(user, user.PasswordHash);
                            existingUser.PasswordHash = newHashedPwd;
                        }

                        var userRoles = await _userManager.GetRolesAsync(existingUser);
                        if(userRoles != null)
                        {
                            await _userManager.RemoveFromRolesAsync(existingUser, userRoles);
                        }
                        foreach (var role in user.Roles)
                        {
                            var roleObj = _roleRepository.Get(x => x.Id == role.RoleId);
                            if (roleObj != null)
                            {
                                await _userManager.AddToRoleAsync(user, roleObj.Name);
                            }
                        }
                        return new { message = "User updated successfully", result = existingUser };
                    }
                    else
                    {
                        return new { message = "User with the given Id not found", result = string.Empty };
                    }
                }
                else
                {
                    return new { message = "User Id cannot be null", result = string.Empty };
                }
            }
            catch (Exception ex)
            {
                return new { message = ex.Message, result = string.Empty };
            }
        }

        public async Task<string> AddUserToRoles(UserToRole mymodel)
        {
            if (mymodel != null)
            {
                User user = await _userManager.FindByEmailAsync(mymodel.Email);
                if (user != null)
                {
                    var roles = await _userManager.GetRolesAsync(user);
                    if (roles.Any())
                    {
                        var resultremove = await _userManager.RemoveFromRolesAsync(user, roles);
                        var resultadd = await _userManager.AddToRolesAsync(user, mymodel.Roles);
                        if (resultadd.Succeeded && resultremove.Succeeded)
                        {
                            return "User Added to Role/s Successfully";
                        }
                        return null;
                    }
                    return null;
                }
            }
            return null;
        }

        public List<object> GetUsersWithRole()
        {
            List<object> usersList = new List<object>();
            IList<string> rolesList = new List<string>();
            try
            {
                List<User> users = _userManager.Users.ToList();
                if (users.Any())
                {
                    foreach(var user in users)
                    {
                        var roles = _userManager.GetRolesAsync(user).Result;
                        usersList.Add(new { user, roles});
                    }
                    return usersList;
                }
                return null;

            }
            catch(Exception ex)
            {
                return usersList;
            }
        }
        public async Task<object> GetUserById(string userId)
        {
            User user = new User();
            List<IdentityRole> userRoles = new List<IdentityRole>();
            try
            {
                if (userId != null)
                {
                    user =await _userManager.FindByIdAsync(userId);
                    
                    List<string> roleNames = _userManager.GetRolesAsync(user).Result.ToList();

                    foreach(var roleName in roleNames) 
                    {
                        userRoles.Add(_roleManager.FindByNameAsync(roleName).Result);
                    }
                    user.PasswordHash = "";
                    return new {user,userRoles};
                }
                return user;
            }
            catch
            {
                return user;
            }
        }
        public object DeleteUser(string userId)
        {
            try
            {
                if (userId != null)
                {
                    User user = _userRepository.Get(u => u.Id == userId);
                    if (user != null)
                    {
                        if (user.IsDeleted == true)
                        {
                            return new { message = "User already deleted", result = string.Empty };
                        }
                        else
                        {
                            user.IsDeleted = true;
                            _userRepository.Remove(user);
                            _userRepository.SaveChanges();
                            return new { message = "User deleted successfully", result = string.Empty };
                        }
                    }
                }
                return new { message = " User id cannot be null", result = string.Empty };

            }
            catch(Exception ex)
            {
                return   new { message = ex.Message, result = string.Empty };
            }
        }

        public List<User> GetUsersList()
        {
            List<User> usersList = new List<User>();
            try
            {
                usersList = _userManager.Users.ToList();
                if(usersList.Count>=1)
                {
                    return usersList;
                }
                return usersList;
            }
            catch(Exception ex)
            {
                return usersList;
            }
        }
        public List<string> GetRolesByUserId(string userId)
        {
            try
            {
                List<string> roleslist = new List<string>();
                if (userId != null)
                {
                    User user = _userManager.FindByIdAsync(userId).Result;
                    roleslist = _userManager.GetRolesAsync(user).Result.ToList();
                    if (roleslist.Any())
                    {
                        return roleslist;
                    }
                }
                return roleslist;
            }
            catch
            {
                return null;
            }
        }
    }
}
