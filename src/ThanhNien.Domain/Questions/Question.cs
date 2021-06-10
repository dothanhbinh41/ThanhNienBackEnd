using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace ThanhNien.Questions
{
    public class Question : Entity<int>
    {
        public string Text { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
    }
}