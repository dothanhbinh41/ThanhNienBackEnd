using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ThanhNien.Data;
using Volo.Abp.DependencyInjection;

namespace ThanhNien.EntityFrameworkCore
{
    public class EntityFrameworkCoreThanhNienDbSchemaMigrator
        : IThanhNienDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreThanhNienDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the ThanhNienMigrationsDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<ThanhNienMigrationsDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}