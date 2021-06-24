using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace ThanhNien.UserResults
{
    public class DepartmentDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        readonly IRepository<Department> departmentRepository;

        public DepartmentDataSeedContributor(IRepository<Department> departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (departmentRepository.Any())
            {
                return;
            }

            await departmentRepository.InsertManyAsync(new Department[] {
                new Department{ Name = "Khoa Công nghệ Thông tin"},
                new Department{ Name = "Khoa Cơ - Điện"},
                new Department{ Name = "Khoa Dầu khí"},
                new Department{ Name = "Khoa Khoa học và Kỹ thuật Địa chất"},
                new Department{ Name = "Khoa Kinh tế - Quản trị kinh doanh"},
                new Department{ Name = "Khoa Mỏ"},
                new Department{ Name = "Khoa Môi trường"},
                new Department{ Name = "Khoa Trắc địa - Bản đồ và Quản lý đất đai"},
                new Department{ Name = "Khoa Xây dựng"},
                new Department{ Name = "Chương trình Tiên tiến"},
            });
        }
    }
}
