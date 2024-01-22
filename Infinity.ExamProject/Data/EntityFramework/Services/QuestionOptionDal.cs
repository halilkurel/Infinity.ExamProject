using Infinity.ExamProject.Data.Context;
using Infinity.ExamProject.Data.EntityFramework.Interfaces;
using Infinity.ExamProject.Dtos.OptionDtos;
using Infinity.ExamProject.Dtos.QuestiionOptionsDtos;
using Microsoft.EntityFrameworkCore;

namespace Infinity.ExamProject.Data.EntityFramework.Services
{
	public class QuestionOptionDal : IQuestionOptionDal
	{
		private readonly InfinityContext _context;

		public QuestionOptionDal(InfinityContext context)
		{
			_context = context;
		}

        public async Task<List<ListOptionDto>> OptionsGetAll(int id)
        {
            var optionsList = await _context.Options
                .Where(option => option.QuestionId == id)
                .ToListAsync();

            var listOptionDtos = optionsList.Select(option => new ListOptionDto
            {
                OptionsId = option.OptionsId,
                OptionName = option.OptionName,
                correctOption = option.correctOption,
                QuestionId = option.QuestionId,
            }).ToList();

            return listOptionDtos;
        }


        public async Task<List<ListOptionDto>> QuestionOptionsGetAll(int examId)
		{
			var optionsList = await _context.Options
				.Where(option => option.Question.Exam.ExamId == examId)
				.Include(option => option.Question)
				.Include(option => option.Question.Exam)
				.ToListAsync();

			var listOptionDtos = optionsList.Select(option => new ListOptionDto
			{
				OptionsId = option.OptionsId,
				OptionName = option.OptionName,
				correctOption = option.correctOption,
				QuestionId = option.Question.QuestionId,
				QuestionName = option.Question.QuestionName,
				ExamName = option.Question.Exam.ExamName,
				ExamId = option.Question.Exam.ExamId
			}).ToList();

			return listOptionDtos;
		}
	}
}
