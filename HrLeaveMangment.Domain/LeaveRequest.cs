using HrLeaveMangment.Domain.Common;

namespace HrLeaveMangment.Domain
{
    public class LeaveRequest : BaseDomainEntity
    {
        public DateTime StartDat { get; set; }

        public LeaveType LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public DateTime DateRequest { get; set; }

        public string RequestComment { get; set; }

        public DateTime? DateActioned { get; set; }
        public bool? Approved { get; set; }

        public bool Cancelled { get; set; }
    }
}