using HrLeaveMangment.Domain;
using HRLeaveMangment.Application.DTOs.LeaveRequests;
using MediatR;

namespace HRLeaveMangment.Application.Features.LeaveRequests.Requests.Commands
{
    public class UpdateLeaveRequestApprovalCommand : IRequest<LeaveRequest>
    {
        public ChangeLeaveRequestApprovalDTO ChangeLeaveRequestApproval { get; set; }
    }
}