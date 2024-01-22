using Infinity.ExamProject.Data.Repositories;

namespace Infinity.ExamProject.Data.UnitOfWork
{
    public interface IUow
    {
        IRepositories<T> GetRepositories<T>() where T : class,new();
        Task SaveChangesAsync();
    }
}
