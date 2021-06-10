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
        Task<ListResultDto<QuestionDto>> GetQuestionsAsync();
        Task<UserResultDto> GetResultAsync(string phone);
        Task<UserResultDto> SubmitAnswersAsync(SubmitAnswersRequestDto request);
        Task<PagedResultDto<UserResultDto>> GetAllResultAsync(PagedResultRequestDto request); 
    }
}
