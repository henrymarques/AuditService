using AuditService.Core.Repositories;
using AuditService.Infra.Config;
using AuditService.Infra.Repositories;
using MongoDB.Driver;

namespace AuditService.Infra
{
    public static class InfraModule
    {
        public static IServiceCollection AddInfra(this IServiceCollection services)
        {
            services.AddMongoDb().AddRepositories();

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRegistryRepository, RegistryRepository>();

            return services;
        }

        public static IServiceCollection AddMongoDb(this IServiceCollection services)
        {
            services.AddSingleton<MongoDbOptions>(serviceProvider =>
            {
                var configuration = serviceProvider.GetService<IConfiguration>();
                var options = new MongoDbOptions();

                configuration?.GetSection("MongoDb").Bind(options);
                return options;
            });

            services.AddSingleton<IMongoClient>(serviceProvider =>
            {
                var configuration = serviceProvider.GetService<IConfiguration>();
                var options = serviceProvider.GetService<MongoDbOptions>();

                return new MongoClient(options?.ConnectionString);
            });

            services.AddTransient(serviceProvider =>
            {
                var options = serviceProvider.GetService<MongoDbOptions>();
                var mongoClient = serviceProvider.GetService<IMongoClient>();
                var database = mongoClient.GetDatabase(options?.Database);

                return database;
            });

            return services;
        }
    }
}
