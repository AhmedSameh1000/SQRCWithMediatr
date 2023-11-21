namespace HRLeaveMangment.Application.DTOs.LeaveAllocations.CommonValidators
{
    public interface IleaveAllocationDTO
    {
        public int NumberOfDays { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
    }
}