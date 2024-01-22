using Infinity.ExamProject.Data.Entities;
using Infinity.ExamProject.Dtos.LoginDtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Infinity.ExamProject.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signIn;
        private readonly UserManager<AppUser> _userManager;

        public LoginController(SignInManager<AppUser> signIn, UserManager<AppUser> userManager)
        {
            _signIn = signIn;
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginUserDto loginUser)
        {
            var result = await _signIn.PasswordSignInAsync(loginUser.Username, loginUser.Password,false,false);
            
            if(result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(loginUser.Username);
                var role = await _userManager.GetRolesAsync(user);
                if(role.Contains("Student"))
                {
                    return RedirectToAction("Index", "StudentPage");
                }
                if (role.Contains("Teacher"))
                {
                    return RedirectToAction("Index", "Category");
                }
                return RedirectToAction("Index", "Register");
            }
            
            return View();
        }
    }
}
