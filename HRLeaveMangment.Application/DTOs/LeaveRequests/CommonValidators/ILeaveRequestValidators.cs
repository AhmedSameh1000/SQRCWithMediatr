namespace HRLeaveMangment.Application.DTOs.LeaveRequests.CommonValidators
{
    public interface ILeaveRequestValidators
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int LeaveTypeId { get; set; }
        public string RequestComments { get; set; }
    }
}