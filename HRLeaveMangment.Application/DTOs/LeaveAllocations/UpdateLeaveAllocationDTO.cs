using HRLeaveMangment.Application.DTOs.Common;
using HRLeaveMangment.Application.DTOs.LeaveAllocations.CommonValidators;

namespace HRLeaveMangment.Application.DTOs.LeaveAllocations
{
    public class UpdateLeaveAllocationDTO : BaseDTO, IleaveAllocationDTO
    {
        public int NumberOfDays { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
    }
}