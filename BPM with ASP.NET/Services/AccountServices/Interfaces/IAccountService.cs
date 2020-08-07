using BPM_with_ASP.NET.Data.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPM_with_ASP.NET.Services.AccountServices.Interfaces
{
    public interface IAccountService
    {
        User Authenticate(string email, string password, HttpContext httpContext);
        User Register(User user, IEnumerable<Role> roles);
        bool Verify(string email, string password);
    }
}
