using Infinity.ExamProject.Bussiness.Interfaces;
using Infinity.ExamProject.Data.Entities;
using Infinity.ExamProject.Data.EntityFramework.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Infinity.ExamProject.Controllers
{
    public class StudentPageController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserExamDal _userExamDal;
        private readonly IOptionService _optionService;

        public StudentPageController(IUserExamDal userExamDal, UserManager<AppUser> userManager, IOptionService optionService)
        {
            _userExamDal = userExamDal;
            _userManager = userManager;
            _optionService = optionService;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var userId = user.Id;

            var list = await _userExamDal.listUserExamDtos(userId); ;
            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> Exam(int id)
        {
            var list = await _optionService.GetAllQuestionOption(id);
            ViewBag.Questions = list.FirstOrDefault()?.ExamId;
            return View(list);
        }



        //Son Olarak Sınav Sayfası Yapılcak
    }
}