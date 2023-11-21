using FluentValidation;
using HRLeaveMangment.Application.DTOs.LeaveTypes.CommonValidators;

namespace HRLeaveMangment.Application.DTOs.LeaveTypes.Validators
{
    public class CreateLeaveTypeDTOValidators : AbstractValidator<CreateLeaveTypeDto>
    {
        public CreateLeaveTypeDTOValidators()
        {
            Include(new LeaveTypeValidators());
        }
    }
}