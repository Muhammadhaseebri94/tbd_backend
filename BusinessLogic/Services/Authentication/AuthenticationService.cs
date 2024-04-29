using Entities.DTOs;
using Entities.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;
using System.Text;
using Microsoft.Extensions.Configuration;
using Data_Access.Generic_Repository;

namespace Business_Logic.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IGenericRepository<RolePermission> _rolePermissionRepository;
        private readonly IGenericRepository<Permission> _permissionRepository;

        public AuthenticationService(SignInManager<User> signInManager, UserManager<User> userManager, RoleManager<IdentityRole> roleManager,IGenericRepository<RolePermission> rolePermissionRepository, IGenericRepository<Permission> permissionRepository)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _rolePermissionRepository = rolePermissionRepository;
            _permissionRepository = permissionRepository;
        }
        public async Task<Object> Login(LoginModel Model, string Key)
        {
            try
            {
                User user = await _userManager.FindByEmailAsync(Model.Email);
                User userDetails = new User();
                List<string> userRoleNames = new List<string>();
                List<IdentityRole> userRoles = new List<IdentityRole>();
                List<Permission> rolePermissions = new List<Permission>();
                List<RolePermission> rolePermissionList = new List<RolePermission>();
                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user,Model.PasswordHash,true,false);
                    if (result.Succeeded)
                    {
                        var token = GenerateJwtToken(user.Id, user.Name, user.Email,Key);
                        userDetails = await _userManager.FindByEmailAsync(user.Email);
                        userRoleNames =_userManager.GetRolesAsync(userDetails).Result.ToList();
                        foreach(var role in userRoleNames)
                        {
                            userRoles.Add(_roleManager.FindByNameAsync(role).Result);
                        }
                        foreach(var  role in userRoles) {
                            rolePermissionList = _rolePermissionRepository.GetAll(x => x.RoleId == role.Id).ToList();
                          /*  foreach(var permission in rolePermissionList)
                            {
                                Permission pObj = _permissionRepository.Get(x => x.Id == permission.PermissionId);
                                rolePermissions.Add(pObj);
                            }*/
                        }
                        
                        return new {result,token, userDetails, userRoles, rolePermissions};
                    }
                    return new { result};
                }
                return "Error in entered data";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        private string GenerateJwtToken(string UserId, string Name, string Email,string Key)
        {
            var claims = new List<Claim>
            {
            new Claim(JwtRegisteredClaimNames.Sub, UserId),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()),
            new Claim(JwtRegisteredClaimNames.UniqueName,Name),
            new Claim (JwtRegisteredClaimNames.Email,Email)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));
            var token = new JwtSecurityToken(
                //issuer: _configuration["Jwt:Issuer"],
                //audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
