using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace ThanhNien.UserResults
{
    public class Department : Entity<int>
    {
        public string Name { get; set; }
    }
}
