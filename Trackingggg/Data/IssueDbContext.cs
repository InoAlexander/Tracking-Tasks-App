using Microsoft.EntityFrameworkCore;
using Trackingggg.Models;

namespace Trackingggg.Data
{
    public class IssueDbContext : DbContext
    {
        // will allow configuration of the db context for dependency injection
        public IssueDbContext(DbContextOptions options) : base(options) {

        }

        public DbSet<Issue> Issues { get; set; }
    }
}
