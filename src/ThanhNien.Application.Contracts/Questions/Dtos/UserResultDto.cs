using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ThanhNien.Questions.Dtos
{
    public class UserResultDto
    {
        public string Classroom { get; set; }
        public string StudentId { get; set; }
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
        public string Classroom { get; set; }
        public string StudentId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; } 
        public List<ResultDto> Answers { get; set; }
    }
}
