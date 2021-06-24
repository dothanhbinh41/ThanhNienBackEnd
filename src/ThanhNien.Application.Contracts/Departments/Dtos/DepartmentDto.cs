using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace ThanhNien.Departments.Dtos
{ 
    public class DepartmentDto : EntityDto<int>
    {
        public string Name { get; set; }
    }
}
