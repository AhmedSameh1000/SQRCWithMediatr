using HRLeaveMangment.Application.DTOs.Common;

namespace HRLeaveMangment.Application.DTOs.LeaveRequests
{
    public class ChangeLeaveRequestApprovalDTO : BaseDTO
    {
        public bool? Approved { get; set; }
    }
}