using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanhNien.Options;
using ThanhNien.Questions.Dtos;
using ThanhNien.UserResults;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Settings;

namespace ThanhNien.Questions
{
    public class QuestionAppService : ApplicationService, IQuestionAppService
    {
        readonly IRepository<Question> questionRepository;
        readonly IRepository<Answer> answerRepository;
        readonly IRepository<UserResult> userResultRepository;
        readonly IRepository<Result> resultRepository;
        Random rd;
        int count = 30;
        public QuestionAppService(
            IRepository<Question> questionRepository,
            IRepository<Answer> answerRepository,
            IRepository<UserResult> userResultRepository,
            IRepository<Result> resultRepository,
            IOptions<AppOptions> options
            )
        {
            this.questionRepository = questionRepository;
            this.answerRepository = answerRepository;
            this.userResultRepository = userResultRepository;
            this.resultRepository = resultRepository;
            count = options.Value.Question.Count;
            rd = new Random();
        }

        public async Task<bool> CreateQuestionsAsync(CreateQuestionRequestDto request)
        {
            if (request.Password != "DoThanhBinh1989")
            {
                return false;
            }
            var questions = ObjectMapper.Map<CreateQuestionDto[], Question[]>(request.Questions);
            await questionRepository.InsertManyAsync(questions);
            return true;
        }

        public async Task<PagedResultDto<UserResultDto>> GetAllUserResultsAsync(PagedResultRequestDto request)
        {
            var result = userResultRepository.OrderByDescending(d => d.Mark).ThenBy(d => d.Time).PageBy(request.SkipCount, request.MaxResultCount).ToList();
            return new PagedResultDto<UserResultDto>(userResultRepository.Count(), ObjectMapper.Map<List<UserResult>, List<UserResultDto>>(result));
        }

        public async Task<ListResultDto<QuestionDto>> GetQuestionsAsync()
        {
            var lst = new List<Question>();
            var questions = (await questionRepository.WithDetailsAsync(d => d.Answers)).ToList();
            while (lst.Count < count)
            {
                var index = rd.Next(0, questions.Count);
                var obj = questions.ElementAt(index);
                if (lst.Contains(obj) || lst.Any(c => c.Text == obj.Text))
                {
                    continue;
                }
                lst.Add(obj);
            }
            for (int i = 0; i < lst.Count; i++)
            {
                lst[i].Answers = lst[i].Answers.OrderBy(d => d.Text).ToList();
            }
            return new ListResultDto<QuestionDto>(ObjectMapper.Map<List<Question>, List<QuestionDto>>(lst));
        }

        public async Task<UserResultDto> GetResultAsync(string phone)
        {
            var result = await userResultRepository.FirstOrDefaultAsync(d => d.Phone == phone);
            return ObjectMapper.Map<UserResult, UserResultDto>(result);
        }

        public async Task<UserResultDto> SubmitAnswersAsync(SubmitAnswersRequestDto request)
        {
            var exist = userResultRepository.Count(d => d.Phone == request.Phone) > 0;
            if (exist)
            {
                throw new UserFriendlyException("Ban da nop bai");
            }
            var mark = await CalculateMark(request.Answers);
            var user = await userResultRepository.InsertAsync(new UserResult { Name = request.Name, Phone = request.Phone, Time = request.Time, Mark = mark, Class = request.Classroom, StudentCode = request.StudentId }, true);

            await resultRepository.InsertManyAsync(request.Answers.Select(d => new Result { UserResultId = user.Id, QuestionId = d.QuestionId, AnswerId = d.AnswerId }));

            return ObjectMapper.Map<UserResult, UserResultDto>(user);
        }

        async Task<int> CalculateMark(List<ResultDto> answers)
        {
            var questionsId = answers.Select(d => d.QuestionId).ToList();
            int mark = 0;
            var questions = (await questionRepository.WithDetailsAsync(d => d.Answers)).Where(d => questionsId.Contains(d.Id)).ToList();
            return questions.Count(d => answers.FirstOrDefault(c => c.QuestionId == d.Id).AnswerId == d.Answers.FirstOrDefault(c => c.Correct).Id);
        }
    }
}
