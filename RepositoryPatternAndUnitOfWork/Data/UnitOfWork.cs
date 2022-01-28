using RepositoryPatternAndUnitOfWork.Core.IConfiguration;
using RepositoryPatternAndUnitOfWork.Core.IRepositories;
using RepositoryPatternAndUnitOfWork.Core.Repositories;

namespace RepositoryPatternAndUnitOfWork.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;
        public INoteRepository Notes { get; private set; }
        public UnitOfWork(ApplicationDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("Logs");

            Notes = new NoteRepository(_context, _logger);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
