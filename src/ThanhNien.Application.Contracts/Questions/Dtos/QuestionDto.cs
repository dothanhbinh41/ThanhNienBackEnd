using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace ThanhNien.Questions.Dtos
{
    public class QuestionDto : EntityDto<int>
    {
        public string Text { get; set; }
        public virtual ICollection<AnswerDto> Answers { get; set; }
    }

    public class AnswerDto : EntityDto<int>
    {
        public string Text { get; set; } 
    }
}
