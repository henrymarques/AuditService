using AuditService.Core.Models;
using AuditService.Core.Repositories;
using AuditService.Core.Services;

namespace AuditService.Application.Services
{
    public class GetAllRegistriesService : IGetAllRegistriesService
    {
        private readonly IRegistryRepository _registryRepository;

        public GetAllRegistriesService(IRegistryRepository registryRepository)
        {
            _registryRepository = registryRepository;

        }

        public async Task<IEnumerable<Registry>> ExecuteAsync(int? page, int? numberOfItemsPerPage)
        {
            return await _registryRepository.GetAllAsync(page, numberOfItemsPerPage);
        }
    }
}
