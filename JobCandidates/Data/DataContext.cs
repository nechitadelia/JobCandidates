using Microsoft.EntityFrameworkCore;

namespace JobCandidates
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<JobCandidate> JobCandidates { get; set; }
    }
}
