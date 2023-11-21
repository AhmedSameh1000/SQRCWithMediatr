using HrLeaveMangment.Domain;

namespace HRLeaveMangment.Application.Contracts.persistence
{
    public interface ILeaveALLocationRepository : IGenericRepository<LeaveAllocation>
    {
        Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id);

        Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails();
    }
}