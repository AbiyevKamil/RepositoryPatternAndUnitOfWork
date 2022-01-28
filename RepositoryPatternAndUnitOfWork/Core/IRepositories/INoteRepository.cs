using RepositoryPatternAndUnitOfWork.Entities;

namespace RepositoryPatternAndUnitOfWork.Core.IRepositories
{
    public interface INoteRepository : IGenericRepository<Note>
    {
        Task<Note> GetNoteTitle(int id);
    }
}
