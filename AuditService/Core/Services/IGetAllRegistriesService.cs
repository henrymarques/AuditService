using AuditService.Core.Models;

namespace AuditService.Core.Services
{
    public interface IGetAllRegistriesService
    {
        public Task<IEnumerable<Registry>> ExecuteAsync(int? page, int? numberOfItemsPerPage);
    }
}
