namespace HRLeaveMangment.Application.DTOs.LeaveTypes.CommonValidators
{
    public interface ILeaveTypeDTO
    {
        public string Name { get; set; }
        public int defaultDays { get; set; }
    }
}