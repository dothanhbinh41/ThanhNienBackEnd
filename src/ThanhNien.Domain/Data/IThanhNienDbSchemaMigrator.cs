using System.Threading.Tasks;

namespace ThanhNien.Data
{
    public interface IThanhNienDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
