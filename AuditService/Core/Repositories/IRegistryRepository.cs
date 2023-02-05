using AuditService.Core.Models;

namespace AuditService.Core.Repositories
{
    public interface IRegistryRepository
    {
        Task<IEnumerable<Registry>> GetAllAsync(int? page, int? numberOfItemsPerPage);
        Task AddAsync(Registry registry);
    }
}
