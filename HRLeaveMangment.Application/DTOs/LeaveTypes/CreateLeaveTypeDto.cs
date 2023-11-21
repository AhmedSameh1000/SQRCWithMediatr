using HRLeaveMangment.Application.DTOs.LeaveTypes.CommonValidators;

namespace HRLeaveMangment.Application.DTOs.LeaveTypes
{
    public class CreateLeaveTypeDto : ILeaveTypeDTO
    {
        public string Name { get; set; }
        public int defaultDays { get; set; }
        public DateTime DateCreated { get; set; }

        public string CreatedBy { get; set; }

        public DateTime LastModifiedData { get; set; }

        public DateTime LastModifiedBy { get; set; }


    }
}