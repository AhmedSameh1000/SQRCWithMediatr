using HRLeaveMangment.Application.DTOs.Common;
using HRLeaveMangment.Application.DTOs.LeaveTypes;

namespace HRLeaveMangment.Application.DTOs.LeaveAllocations
{
    public class LeaveAllocationDto : BaseDTO
    {
        public int NumberOfDays { get; set; }
        public LeaveTypeDto LeaveTypeDto { get; set; }

        public int LeaveTypeId { get; set; }
        public int period { get; set; }
    }
}