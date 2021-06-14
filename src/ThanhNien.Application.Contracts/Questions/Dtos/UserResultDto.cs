using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ThanhNien.Questions.Dtos
{
    public class UserResultDto
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public long Time { get; set; }
        public int Mark { get; set; }
    }

    public class ResultDto
    {
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }
    }

    public class SubmitAnswersRequestDto
    {
        public string Class { get; set; }
        public string StudentCode { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        [Required]
        [Range(1.0,double.MaxValue)]
        public long Time { get; set; } 
        public List<ResultDto> Answers { get; set; }
    }
}
