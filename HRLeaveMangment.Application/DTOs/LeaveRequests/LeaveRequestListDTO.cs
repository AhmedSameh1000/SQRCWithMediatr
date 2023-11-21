using HRLeaveMangment.Application.DTOs.LeaveTypes;

namespace HRLeaveMangment.Application.DTOs.LeaveRequests
{
    public class LeaveRequestListDTO
    {
        public LeaveTypeDto LeaveType { get; set; }
        public DateTime DateRequested { get; set; }

        public bool? Approved { get; set; }
    }
}