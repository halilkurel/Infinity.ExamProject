using System.Linq.Expressions;

namespace Infinity.ExamProject.Data.Repositories
{
    public interface IRepositories<T> where T : class, new()
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetById(int id);
        Task<T> GetByFilter(Expression<Func<T, bool>> filter, bool asNoTraking=false);
        Task Create(T entity);
        void Update(T entity,T unchanged);
        void Remove(T entity);
    }
}
