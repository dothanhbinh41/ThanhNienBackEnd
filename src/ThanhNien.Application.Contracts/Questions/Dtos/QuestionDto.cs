using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace ThanhNien.Questions.Dtos
{
    public class QuestionDto : EntityDto<int>
    {
        public string Text { get; set; }
        public virtual ICollection<AnswerDto> Answers { get; set; }
    }

    public class CreateQuestionRequestDto
    {
        [Required]
        public CreateQuestionDto[] Questions { get; set; }
    }

    public class CreateQuestionDto
    {
        [Required]
        public string Text { get; set; }
        [Required]
        public virtual ICollection<CreateAnswerDto> Answers { get; set; }
    }
    public class CreateAnswerDto
    {
        [Required]
        public string Text { get; set; }
        public bool Correct { get; set; }
    }
    public class AnswerDto : EntityDto<int>
    {
        public string Text { get; set; }
    }
}
