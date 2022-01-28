using Microsoft.EntityFrameworkCore;
using RepositoryPatternAndUnitOfWork.Core.IRepositories;
using RepositoryPatternAndUnitOfWork.Data;

namespace RepositoryPatternAndUnitOfWork.Core.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected ApplicationDbContext _context;
        protected ILogger _logger;
        protected DbSet<T> dbSet;

        public GenericRepository(ApplicationDbContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
            dbSet = context.Set<T>();
        }

        public virtual async Task<bool> Add(T entity)
        {
            dbSet.Add(entity);
            return true;
        }

        public virtual async Task<IEnumerable<T>> All()
        {
            return await dbSet.ToListAsync();
        }

        public virtual async Task<bool> DeleteById(int id)
        {
            var entity = await dbSet.FindAsync(id);
            if (entity == null)
                return false;
            dbSet.Remove(entity);
            return true;
        }

        public virtual async Task<T> GetById(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task<bool> Update(T entity)
        {
            var exist = await dbSet.FindAsync(entity);
            if (exist == null)
                return false;
            dbSet.Update(entity);
            return true;
        }
    }
}
