using Entities.DTOs;
using Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.UserService
{
    public interface IUserService
    {
        public Task<object> CreateUser(User user);
        public Task<object> UpdateUser(User user);
        public Task<string> AddUserToRoles(UserToRole addtorole);
        public List<object> GetUsersWithRole();
        public List<User> GetUsersList();
        public Task<object> GetUserById(string userId);
        public object DeleteUser(string userId);
        public List<string> GetRolesByUserId(string userId);

    }
}
