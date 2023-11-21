using HRLeaveMangment.Application.DTOs.Common;
using HRLeaveMangment.Application.DTOs.LeaveTypes.CommonValidators;

namespace HRLeaveMangment.Application.DTOs.LeaveTypes
{
    public class LeaveTypeDto : BaseDTO, ILeaveTypeDTO
    {
        public string Name { get; set; }
        public int defaultDays { get; set; }
    }
}