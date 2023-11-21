using HrLeaveMangment.Domain;
using HrLeaveMangment.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace HRLeaveMangment.Persistence
{
    public class HRLeaveMangmentDbContext : DbContext
    {
        public HRLeaveMangmentDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HRLeaveMangmentDbContext).Assembly);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<BaseDomainEntity>())
            {
                entry.Entity.LastModifiedData = DateTime.UtcNow;
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.UtcNow;
                }
            }
            return base.SaveChanges();
        }

        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }

        public DbSet<LeaveAllocation> LeaveAllocations { get; set; }
    }
}