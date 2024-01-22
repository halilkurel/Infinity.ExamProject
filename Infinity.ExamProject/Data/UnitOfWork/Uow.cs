using Infinity.ExamProject.Data.Context;
using Infinity.ExamProject.Data.Repositories;

namespace Infinity.ExamProject.Data.UnitOfWork
{
    public class Uow : IUow
    {
        private readonly InfinityContext _context;

        public Uow(InfinityContext context)
        {
            _context = context;
        }

        public IRepositories<T> GetRepositories<T>() where T : class, new()
        {
            return new Repositories<T>(_context);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
