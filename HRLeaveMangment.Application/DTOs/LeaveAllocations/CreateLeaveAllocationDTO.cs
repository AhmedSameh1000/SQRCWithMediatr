using HRLeaveMangment.Application.DTOs.LeaveAllocations.CommonValidators;

namespace HRLeaveMangment.Application.DTOs.LeaveAllocations
{
    public class CreateLeaveAllocationDTO : IleaveAllocationDTO
    {
        public int NumberOfDays { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
    }
}