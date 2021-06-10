using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace ThanhNien.Data
{
    /* This is used if database provider does't define
     * IThanhNienDbSchemaMigrator implementation.
     */
    public class NullThanhNienDbSchemaMigrator : IThanhNienDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}