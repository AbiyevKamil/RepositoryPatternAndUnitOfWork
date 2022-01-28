using RepositoryPatternAndUnitOfWork.Core.IRepositories;

namespace RepositoryPatternAndUnitOfWork.Core.IConfiguration
{
    public interface IUnitOfWork
    {
        INoteRepository Notes { get; }

        Task CompleteAsync();
    }
}
