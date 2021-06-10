using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using Volo.Abp.Domain.Entities.Auditing;

namespace ThanhNien.UserResults
{
    public class UserResult : FullAuditedEntity<int>
    {
        public string Phone { get; set; }
        public string Name { get; set; }
        public long Time { get; set; }// second
        public int? Mark { get; set; }
        public virtual ICollection<Result> Results { get; set; }
    }
}
