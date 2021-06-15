using AutoMapper;
using ThanhNien.Questions;
using ThanhNien.Questions.Dtos;
using ThanhNien.UserResults;

namespace ThanhNien
{
    public class ThanhNienApplicationAutoMapperProfile : Profile
    {
        public ThanhNienApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<CreateQuestionDto, Question>();
            CreateMap<CreateAnswerDto, Answer>();
            CreateMap<UserResult, UserResultDto>()
                .ForMember(d => d.Classroom, d => d.MapFrom(c => c.Class))
                .ForMember(d => d.StudentId, d => d.MapFrom(c => c.StudentCode));
            CreateMap<Question, QuestionDto>();
            CreateMap<Answer, AnswerDto>();
            CreateMap<CreateAnswerDto, Answer>();
        }
    }
}
