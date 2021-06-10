using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace ThanhNien.EntityFrameworkCore
{
    public static class ThanhNienDbContextModelCreatingExtensions
    {
        public static void ConfigureThanhNien(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(ThanhNienConsts.DbTablePrefix + "YourEntities", ThanhNienConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});
        }
    }
}