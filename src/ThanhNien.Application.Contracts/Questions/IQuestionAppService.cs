using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ThanhNien.Questions.Dtos;
using Volo.Abp.Application.Dtos;

namespace ThanhNien.Questions
{
    public interface IQuestionAppService
    {
        //Task<ListResultDto<QuestionDto>> GetQuestionsAsync();
        Task<ListResultDto<QuestionDto>> GetQuestionsAsync(string phone);
        Task<DateTime> GetStartTimeAsync(string phone);
        Task<UserResultDto> GetResultAsync(string phone);
        Task<UserResultDto> SubmitAnswersAsync(SubmitAnswersRequestDto request);
        Task<PagedResultDto<UserResultDto>> GetAllUserResultsAsync(PagedResultRequestDto request);
        Task<bool> CreateQuestionsAsync(CreateQuestionRequestDto request);
    }
}
