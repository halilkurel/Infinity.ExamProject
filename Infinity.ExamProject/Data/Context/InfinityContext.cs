using Infinity.ExamProject.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infinity.ExamProject.Data.Context
{
    public class InfinityContext : IdentityDbContext<AppUser,AppRole,int>
    {
        public InfinityContext(DbContextOptions<InfinityContext> options): base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Options> Options { get; set; }
        public DbSet<UsersExams> UsersExams { get; set; }


    }
}
