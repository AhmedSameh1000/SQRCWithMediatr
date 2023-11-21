using HrLeaveMangment.Domain;
using HRLeaveMangment.Application.Contracts.persistence;

namespace HRLeaveMangment.Persistence.Repositories
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        private readonly HRLeaveMangmentDbContext _dbContext;

        public LeaveTypeRepository(HRLeaveMangmentDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}