using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ThanhNien.Departments.Dtos;
using Volo.Abp.Application.Dtos;

namespace ThanhNien.Departments
{
    public interface IDepartmentAppService
    {
        Task<ListResultDto<DepartmentDto>> GetAllDepartmentAsync(); 
    }
}
