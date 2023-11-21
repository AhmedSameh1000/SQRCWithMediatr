using HrLeaveMangment.Domain;
using HRLeaveMangment.Application.Contracts.persistence;
using Microsoft.EntityFrameworkCore;

namespace HRLeaveMangment.Persistence.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveALLocationRepository
    {
        private readonly HRLeaveMangmentDbContext _dbContext;

        public LeaveAllocationRepository(HRLeaveMangmentDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails()
        {
            var LeaveAllocation = await _dbContext.LeaveAllocations
                 .Include(c => c.LeaveType)
                 .ToListAsync();

            return LeaveAllocation;
        }

        public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id)
        {
            var LeaveAllocation = await _dbContext.LeaveAllocations
                 .Include(c => c.LeaveType)
                 .FirstOrDefaultAsync(c => c.Id == id);

            return LeaveAllocation;
        }
    }
}