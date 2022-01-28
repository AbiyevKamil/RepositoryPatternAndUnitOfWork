using Microsoft.EntityFrameworkCore;
using RepositoryPatternAndUnitOfWork.Entities;

namespace RepositoryPatternAndUnitOfWork.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}
