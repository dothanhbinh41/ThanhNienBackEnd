using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanhNien.Questions;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace ThanhNien.UserResults
{
    public class Result : Entity<int>
    {
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }
        public int UserResultId { get; set; }

        [ForeignKey(nameof(QuestionId))]
        public virtual Question Question { get; set; }

        [ForeignKey(nameof(AnswerId))]
        public virtual Answer Answer { get; set; }

        [ForeignKey(nameof(UserResultId))]
        public virtual UserResult UserResult { get; set; }
    }
}
