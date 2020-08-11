using LibraryTest.NET.Data.Models;
using LibraryTest.NET.Data.Repositories.ModelRepository;

namespace LibraryTest.NET.Data.Repositories.Interfaces
{
    public interface IRoleRepository : IModelRepository<Role>
    {
        Role Get(string name);
    }
}
