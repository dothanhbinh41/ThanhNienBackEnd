using Microsoft.EntityFrameworkCore;
using ThanhNien.Questions;
using ThanhNien.UserResults;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace ThanhNien.EntityFrameworkCore
{
    public static class ThanhNienDbContextModelCreatingExtensions
    {
        public static void ConfigureThanhNien(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));
            builder.Entity<Question>(b =>
            {
                b.ToTable(ThanhNienConsts.DbTablePrefix + "Questions", ThanhNienConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props 
            });
            builder.Entity<Answer>(b =>
            {
                b.ToTable(ThanhNienConsts.DbTablePrefix + "Answers", ThanhNienConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props 
            });
            builder.Entity<Result>(b =>
            {
                b.ToTable(ThanhNienConsts.DbTablePrefix + "Results", ThanhNienConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props 
            });
            builder.Entity<UserResult>(b =>
            {
                b.ToTable(ThanhNienConsts.DbTablePrefix + "UserResults", ThanhNienConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props 
            });
            builder.Entity<ResultTime>(b =>
            {
                b.ToTable(ThanhNienConsts.DbTablePrefix + "ResultTimes", ThanhNienConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props 
            });
            builder.Entity<Department>(b =>
            {
                b.ToTable(ThanhNienConsts.DbTablePrefix + "Departments", ThanhNienConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props 
            });
        }
    }
}