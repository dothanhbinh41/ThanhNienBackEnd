using IdentityServer4.Services;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanhNien.Departments.Dtos;
using ThanhNien.UserResults;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Caching;
using Volo.Abp.Domain.Repositories;

namespace ThanhNien.Departments
{
    public class DepartmentAppService : ApplicationService, IDepartmentAppService
    {
        private readonly IRepository<Department> departmentRepository;
        private readonly IDistributedCache<DepartmentDto[]> cache;

        public DepartmentAppService(IRepository<Department> departmentRepository, IDistributedCache<DepartmentDto[]> cache)
        {
            this.departmentRepository = departmentRepository;
            this.cache = cache;
        }

        public async Task<ListResultDto<DepartmentDto>> GetAllDepartmentAsync()
        {
            var departments = await cache.GetOrAddAsync("AlLDepartment", async () => await GetDepartmentAsync(), () => new DistributedCacheEntryOptions
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddDays(1)
            });

            return new ListResultDto<DepartmentDto>(departments);
        }

        async Task<DepartmentDto[]> GetDepartmentAsync()
        {
            var all = await departmentRepository.ToArrayAsync();
            return ObjectMapper.Map<Department[], DepartmentDto[]>(all);
        } 
    }
}
