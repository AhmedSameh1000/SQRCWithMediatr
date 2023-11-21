using HRLeaveMangment.Application.DTOs.Common;
using HRLeaveMangment.Application.DTOs.LeaveRequests.CommonValidators;

namespace HRLeaveMangment.Application.DTOs.LeaveRequests
{
    public class UpdateLeaveRequestDTO : BaseDTO, ILeaveRequestValidators
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int LeaveTypeId { get; set; }
        public string RequestComments { get; set; }

        public bool Cancelled { get; set; }
    }
}