using Entities.DTOs;
using Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.Services.Authentication
{
    public interface IAuthenticationService
    {
        public Task<Object> Login(LoginModel Model,string Key);

    }
}
