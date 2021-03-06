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
        readonly IRepository<ResultTime> resultTimeRepository;
        Random rd;
        int count = 30;
        public QuestionAppService(
            IRepository<Question> questionRepository,
            IRepository<Answer> answerRepository,
            IRepository<UserResult> userResultRepository,
            IRepository<Result> resultRepository,
            IRepository<ResultTime> resultTimeRepository,
            IOptions<AppOptions> options
            )
        {
            this.questionRepository = questionRepository;
            this.answerRepository = answerRepository;
            this.userResultRepository = userResultRepository;
            this.resultRepository = resultRepository;
            this.resultTimeRepository = resultTimeRepository;
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
            var result = (await userResultRepository.WithDetailsAsync(d => d.Department))
                .OrderByDescending(d => d.Mark).ThenBy(d => d.Time).PageBy(request.SkipCount, request.MaxResultCount).ToList();
            return new PagedResultDto<UserResultDto>(userResultRepository.Count(), ObjectMapper.Map<List<UserResult>, List<UserResultDto>>(result));
        }

        async Task<ListResultDto<QuestionDto>> GetQuestionsAsync()
        {
            var lst = new List<Question>();
            var questions = (await questionRepository.WithDetailsAsync(d => d.Answers)).ToList();
            if (questions.Count < count)
            {
                throw new UserFriendlyException("Không đủ câu hỏi");
            }
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

        public async Task<ListResultDto<QuestionDto>> GetQuestionsAsync(string phone)
        {
            var exist = resultTimeRepository.OrderBy(d => d.Id).LastOrDefault(d => d.Phone == phone);
            if (exist != null)
            {
                throw new UserFriendlyException("Bạn đã làm bài");
            }
            var time = await resultTimeRepository.InsertAsync(new ResultTime { Date = DateTime.UtcNow, Phone = phone });
            return await GetQuestionsAsync();
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
                throw new UserFriendlyException("Bạn đã nộp bài");
            }
            var mark = await CalculateMark(request.Answers);
            var time = resultTimeRepository.OrderBy(d => d.Id).LastOrDefault(d => d.Phone == request.Phone);
            if (time == null)
            {
                throw new UserFriendlyException("Bạn chưa làm bài");
            }

            var totalSeconds = (int)Math.Round(DateTime.UtcNow.Subtract(time.Date).TotalSeconds);
            var user = await userResultRepository.InsertAsync(new UserResult
            {
                Name = request.Name,
                Phone = request.Phone,
                Time = totalSeconds,
                Mark = mark,
                Class = request.Classroom,
                StudentCode =
                request.StudentId,
                DepartmentId = request.DepartmentId
            }, true);

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

        public async Task<DateTime> GetStartTimeAsync(string phone)
        {
            var exist = resultTimeRepository.OrderBy(d => d.Id).LastOrDefault(d => d.Phone == phone);
            return exist.Date;
        }

        public async Task<ListResultDto<TopDepartmentDto>> GetTopDepartment()
        {
            var groups = (await userResultRepository.WithDetailsAsync(d => d.Department)).ToList().GroupBy(d => d.Department)
                 .OrderByDescending(d => d.Sum(c => c.Mark ?? 0))
                 .ThenBy(d => d.Sum(c => c.Time))
                 .ToList();

            var tops = groups.Select(d => new TopDepartmentDto
            {
                Name = d.Key.Name,
                TotalMark = d.Sum(c => c.Mark ?? 0),
                TotalTime = d.Sum(c => c.Time),
                Student = d.Count(),
                Rank = groups.FindIndex(c => c.Key.Id == d.Key.Id) + 1
            }).ToList();

            return new ListResultDto<TopDepartmentDto>(tops);
        }
    }
}