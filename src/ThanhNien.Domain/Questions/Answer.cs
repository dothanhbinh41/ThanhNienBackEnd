using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace ThanhNien.Questions
{
    public class Answer : FullAuditedEntity<int>
    {
        public int QuestionId { get; set; }
        public string Text { get; set; }
        public bool Correct { get; set; }

        [ForeignKey(nameof(QuestionId))] 
        public virtual Question Question { get; set; }
    }
}
