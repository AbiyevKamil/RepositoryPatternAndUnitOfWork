using RepositoryPatternAndUnitOfWork.Core.IRepositories;
using RepositoryPatternAndUnitOfWork.Data;
using RepositoryPatternAndUnitOfWork.Entities;

namespace RepositoryPatternAndUnitOfWork.Core.Repositories
{
    public class NoteRepository : GenericRepository<Note>, INoteRepository
    {
        public NoteRepository(ApplicationDbContext context, ILogger logger)
            : base(context, logger)
        {
        }

        public async Task<Note> GetNoteTitle(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public override async Task<bool> Update(Note entity)
        {
            try
            {
                var exist = await dbSet.FindAsync(entity);
                if (exist == null) return false;
                exist.Title = entity.Title;
                exist.Description = entity.Description;
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Update method error", typeof(NoteRepository));
                return false;
            }
        }
    }
}
