using HRLeaveMangment.Application.DTOs.LeaveRequests.CommonValidators;

namespace HRLeaveMangment.Application.DTOs.LeaveRequests
{
    public class CreateLeaveRequestDTO : ILeaveRequestValidators
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int LeaveTypeId { get; set; }
        public string RequestComments { get; set; }
    }
}