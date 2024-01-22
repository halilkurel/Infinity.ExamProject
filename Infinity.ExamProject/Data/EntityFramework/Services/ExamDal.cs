using Infinity.ExamProject.Bussiness.Interfaces;
using Infinity.ExamProject.Data.Context;
using Infinity.ExamProject.Data.EntityFramework.Interfaces;
using Infinity.ExamProject.Dtos.ExamDtos;
using Microsoft.EntityFrameworkCore;

namespace Infinity.ExamProject.Data.EntityFramework.Services
{
	public class ExamDal : IExamDal
	{
		private readonly InfinityContext _context;

		public ExamDal(InfinityContext context)
		{
			_context = context;
		}

		public async Task<CreateExamDto> CreateExamAsync(CreateExamDto createExamDto)
		{
			return createExamDto;
		}

		public async Task<List<ListExamDto>> GetAllExam()
		{
			var list = await _context.Exams
				.Include(x => x.Categories)
				.ToListAsync();

			var result = list.Select(x => new ListExamDto
			{
				ExamId = x.ExamId,
				ExamName = x.ExamName,
				CategoryId = x.CategoryId,
				CategoryName = x.Categories.CategoryName
			}).ToList();

			return result;
		}
	}
}
