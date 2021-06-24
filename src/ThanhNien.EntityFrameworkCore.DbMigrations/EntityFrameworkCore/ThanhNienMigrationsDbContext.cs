using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
//using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;

namespace ThanhNien.EntityFrameworkCore
{
    /* This DbContext is only used for database migrations.
     * It is not used on runtime. See ThanhNienDbContext for the runtime DbContext.
     * It is a unified model that includes configuration for
     * all used modules and your application.
     */
    public class ThanhNienMigrationsDbContext : AbpDbContext<ThanhNienMigrationsDbContext>
    {
        public ThanhNienMigrationsDbContext(DbContextOptions<ThanhNienMigrationsDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /* Include modules to your migration db context */
             
          //  builder.ConfigureSettingManagement();
           // builder.ConfigureBackgroundJobs();
           // builder.ConfigureAuditLogging(); 

            /* Configure your own tables/entities inside the ConfigureThanhNien method */

            builder.ConfigureThanhNien();
        }
    }
}