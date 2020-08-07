using BPM_with_ASP.NET.Data.Models;
using BPM_with_ASP.NET.Data.Repositories.ModelRepository;

namespace BPM_with_ASP.NET.Data.Repositories.Interfaces
{
    public interface IRoleRepository : IModelRepository<Role>
    {
        Role Get(string name);
    }
}
