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
            
        }
    }
}
