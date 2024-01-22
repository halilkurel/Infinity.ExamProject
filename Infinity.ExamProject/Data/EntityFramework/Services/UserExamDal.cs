
using Infinity.ExamProject.Data.Context;
using Infinity.ExamProject.Data.EntityFramework.Interfaces;
using Infinity.ExamProject.Dtos.ExamDtos;
using Infinity.ExamProject.Dtos.UserExamDtos;
using Microsoft.EntityFrameworkCore;

namespace Infinity.ExamProject.Data.EntityFramework.Services
{
	public class UserExamDal : IUserExamDal
	{
		private readonly InfinityContext _context;

		public UserExamDal(InfinityContext context)
		{
			_context = context;
		}

		public async Task<List<ListUserExamDto>> listUserExamDtos(int id)
		{
			var list = await _context.UsersExams
				.Where(x => x.AppUserId == id)
				.Include(y => y.AppUser)
				.Include(z => z.Exam)
				.ToListAsync();

			var result = list.Select(x => new ListUserExamDto
			{
				UsersExamsId = x.UsersExamsId,
				StartTime = x.StartTime, 
				EndTime = x.EndTime,
				ListAppUserDto = new Dtos.AppUserDtos.ListAppUserDto()
				{
					Id = x.AppUser.Id,
					Name = x.AppUser.Name,
					Surname = x.AppUser.Surname,
					Username = x.AppUser.UserName
				},

				ListExamDtos = new List<ListExamDto>
				{
					new ListExamDto
					{
						ExamId = x.Exam.ExamId,
						ExamName = x.Exam.ExamName,
						CategoryName = x.Exam.Categories?.CategoryName,
						CategoryId = x.Exam.CategoryId
					}
				}

			}).ToList();
			return result;
		}
	}
}
