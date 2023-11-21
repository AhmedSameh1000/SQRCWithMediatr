using HrLeaveMangment.Domain;
using HRLeaveMangment.Application.Contracts.persistence;
using Microsoft.EntityFrameworkCore;

namespace HRLeaveMangment.Persistence.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        private readonly HRLeaveMangmentDbContext _dbContext;

        public LeaveRequestRepository(HRLeaveMangmentDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task ChangeApproval(LeaveRequest leaveRequest, bool? Approvalstate)
        {
            leaveRequest.Approved = Approvalstate;
            _dbContext.Entry(leaveRequest).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetails()
        {
            var LeaveRequests = await _dbContext.LeaveRequests
                  .Include(c => c.LeaveType)
                  .ToListAsync();

            return LeaveRequests;
        }

        public async Task<LeaveRequest> GetLeaveRequestWithDetails(int id)
        {
            var LeaveRequest = await _dbContext.LeaveRequests
                 .Include(c => c.LeaveType)
                 .FirstOrDefaultAsync(c => c.Id == id);

            return LeaveRequest;
        }
    }
}