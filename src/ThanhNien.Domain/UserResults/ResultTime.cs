using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace ThanhNien.UserResults
{
    public class ResultTime : Entity<int>
    {
        public string Phone { get; set; }
        public DateTime Date { get; set; } 
    }
}
