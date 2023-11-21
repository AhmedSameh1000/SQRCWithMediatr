using HrLeaveMangment.Domain;

namespace HRLeaveMangment.Application.Contracts.persistence
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        Task<LeaveRequest> GetLeaveRequestWithDetails(int id);

        Task<List<LeaveRequest>> GetLeaveRequestsWithDetails();

        Task ChangeApproval(LeaveRequest leaveRequest, bool? Approvalstate);
    }
}