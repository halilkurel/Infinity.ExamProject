using AutoMapper;
using Infinity.ExamProject.Bussiness.Interfaces;
using Infinity.ExamProject.Bussiness.Mappings.AutoMapper;
using Infinity.ExamProject.Bussiness.Services;
using Infinity.ExamProject.Data.Context;
using Infinity.ExamProject.Data.Entities;
using Infinity.ExamProject.Data.EntityFramework.Interfaces;
using Infinity.ExamProject.Data.EntityFramework.Services;
using Infinity.ExamProject.Data.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infinity.ExamProject.Bussiness.DependencyResolvers
{
    public static class DependencyExtension
    {
        public static void AddDependency(this IServiceCollection services)
        {
            services.AddDbContext<InfinityContext>(opt =>
            {
                opt.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=InfinityExamDb;Trusted_Connection=True;TrustServerCertificate=True");
            });

            var configuration = new MapperConfiguration(opt =>
            {
                opt.AddProfile(new CategoryProfile());
                opt.AddProfile(new QuestionProfile());
                opt.AddProfile(new ExamProfile());
                opt.AddProfile(new OptionProfile());
                opt.AddProfile(new AppUserProfile());
                opt.AddProfile(new LoginUserProfile());
                opt.AddProfile(new UserExamMapping());
            });

            var mapper = configuration.CreateMapper();
            services.AddSingleton(mapper);

            services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<InfinityContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<UserManager<AppUser>>();

            services.AddScoped<IUow, Uow>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IExamService, ExamService>();
            services.AddScoped<IQuestionService, QuestionService>();
            services.AddScoped<IOptionService, OptionService>();
            services.AddScoped<IExamDal,ExamDal>();
            services.AddScoped<IQuestionOptionDal,QuestionOptionDal>();
            services.AddScoped<IUserExamService,UserExamService>();
            services.AddScoped<IUserExamDal,UserExamDal>();


        }
    }
}
