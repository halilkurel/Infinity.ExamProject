using Infinity.ExamProject.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infinity.ExamProject.Data.Repositories
{
    public class Repositories<T> : IRepositories<T> where T : class, new()
    {
        private readonly InfinityContext _context;

        public Repositories(InfinityContext context)
        {
            _context = context;
        }

        public async Task Create(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByFilter(Expression<Func<T, bool>> filter, bool asNoTraking = false)
        {
            return asNoTraking ? await _context.Set<T>().SingleOrDefaultAsync(filter):
                await _context.Set<T>().FirstOrDefaultAsync(filter);
        }

        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Update(T entity,T unchanged)
        {
            _context.Entry(unchanged).CurrentValues.SetValues(entity);
        }
    }
}
