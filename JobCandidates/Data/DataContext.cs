using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JobCandidates
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<JobCandidate> JobCandidates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var timeOnlyConverter = new ValueConverter<TimeOnly, TimeSpan>(
                t => t.ToTimeSpan(),
                t => TimeOnly.FromTimeSpan(t)
            );

            modelBuilder.Entity<JobCandidate>()
                .Property(e => e.StartTimeInterval)
                .HasConversion(timeOnlyConverter);

            modelBuilder.Entity<JobCandidate>()
                .Property(e => e.EndTimeInterval)
                .HasConversion(timeOnlyConverter);
        }
    }
}
