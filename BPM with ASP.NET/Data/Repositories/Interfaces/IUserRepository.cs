using BPM_with_ASP.NET.Data.Models;
using BPM_with_ASP.NET.Data.Repositories.ModelRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPM_with_ASP.NET.Data.Repositories.Interfaces
{
    public interface IUserRepository : IModelRepository<User>
    {
        User Get(string email);
    }
}
