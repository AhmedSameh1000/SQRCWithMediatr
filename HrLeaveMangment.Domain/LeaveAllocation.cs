using HrLeaveMangment.Domain.Common;

namespace HrLeaveMangment.Domain
{
    public class LeaveAllocation : BaseDomainEntity
    {
        //public int Id { get; set; }
        public int NumberOfDays { get; set; }

        //public DateTime DateCreated { get; set; }

        public LeaveType LeaveType { get; set; }

        public int LeaveTypeId { get; set; }
        public int period { get; set; }
    }
}