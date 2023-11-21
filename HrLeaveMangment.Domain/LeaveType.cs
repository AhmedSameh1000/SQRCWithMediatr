using HrLeaveMangment.Domain.Common;

namespace HrLeaveMangment.Domain
{
    public class LeaveType : BaseDomainEntity
    {
        public string Name { get; set; }
        public int defaultDays { get; set; }
    }
}