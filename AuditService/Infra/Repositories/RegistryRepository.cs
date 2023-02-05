using AuditService.Core.Models;
using AuditService.Core.Repositories;
using MongoDB.Driver;

namespace AuditService.Infra.Repositories
{
    public class RegistryRepository : IRegistryRepository
    {
        private readonly IMongoCollection<Registry> _collection;

        public RegistryRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<Registry>("registry");
        }

        public async Task AddAsync(Registry registry)
        {
            await _collection.InsertOneAsync(registry);
        }

        public async Task<IEnumerable<Registry>> GetAllAsync(int? page = 0, int? numberOfItemsPerPage = 0)
        {
            var startIndex = page > 0 ? (page - 1 * numberOfItemsPerPage) : 0;

            return await _collection
                .Find(c => true)
                .Skip(startIndex)
                .Limit(numberOfItemsPerPage)
                .ToListAsync();
        }
    }
}
