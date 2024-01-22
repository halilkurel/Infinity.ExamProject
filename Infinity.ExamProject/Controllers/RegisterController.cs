using Infinity.ExamProject.Data.Entities;
using Infinity.ExamProject.Dtos.RegisterDtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Infinity.ExamProject.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateNewUserDto createNewUser)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            var appUser = new AppUser()
            {
                Name = createNewUser.Name,
                Surname = createNewUser.Surname,
                UserName = createNewUser.Username,
                Email = createNewUser.Mail
            };
            var result = await _userManager.CreateAsync(appUser,createNewUser.Password);
            
            if(result.Succeeded)
            {
                // Her Kayıt için Öğrenci Rolü atanır
                await _userManager.AddToRoleAsync(appUser, "Student");
                return RedirectToAction("Index","Register");
            }
            return View();
        }
    }
}
