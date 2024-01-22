using Microsoft.AspNetCore.Identity;

namespace Infinity.ExamProject.Data.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public List<UsersExams> UsersExams { get; set; }
    }
}
