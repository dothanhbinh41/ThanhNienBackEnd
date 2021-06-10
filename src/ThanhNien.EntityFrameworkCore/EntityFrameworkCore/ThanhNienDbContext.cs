using Microsoft.EntityFrameworkCore;
using ThanhNien.Questions;
using ThanhNien.UserResults; 
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.Identity; 

namespace ThanhNien.EntityFrameworkCore
{
    /* This is your actual DbContext used on runtime.
     * It includes only your entities.
     * It does not include entities of the used modules, because each module has already
     * its own DbContext class. If you want to share some database tables with the used modules,
     * just create a structure like done for AppUser.
     *
     * Don't use this DbContext for database migrations since it does not contain tables of the
     * used modules (as explained above). See ThanhNienMigrationsDbContext for migrations.
     */
    [ConnectionStringName("Default")]
    public class ThanhNienDbContext : AbpDbContext<ThanhNienDbContext>
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<UserResult> UserResults { get; set; }

        /* Add DbSet properties for your Aggregate Roots / Entities here.
         * Also map them inside ThanhNienDbContextModelCreatingExtensions.ConfigureThanhNien
         */

        public ThanhNienDbContext(DbContextOptions<ThanhNienDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /* Configure the shared tables (with included modules) here */

            /* Configure your own tables/entities inside the ConfigureThanhNien method */

            builder.ConfigureThanhNien();
        }
    }
}
