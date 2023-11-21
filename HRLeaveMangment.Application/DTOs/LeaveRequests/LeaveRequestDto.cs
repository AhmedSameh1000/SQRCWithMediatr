using HRLeaveMangment.Application.DTOs.Common;
using HRLeaveMangment.Application.DTOs.LeaveTypes;

namespace HRLeaveMangment.Application.DTOs.LeaveRequests
{
    public class LeaveRequestDto : BaseDTO
    {
        public DateTime StartDat { get; set; }

        public LeaveTypeDto LeaveTypeDto { get; set; }
        public int LeaveTypeId { get; set; }
        public DateTime DateRequest { get; set; }

        public string RequestComment { get; set; }

        public DateTime? DateActioned { get; set; }
        public bool? Approved { get; set; }

        public bool Cancelled { get; set; }
    }
}