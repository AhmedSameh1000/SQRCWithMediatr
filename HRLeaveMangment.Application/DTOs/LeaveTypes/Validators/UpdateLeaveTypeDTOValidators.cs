using FluentValidation;
using HRLeaveMangment.Application.DTOs.LeaveTypes.CommonValidators;

namespace HRLeaveMangment.Application.DTOs.LeaveTypes.Validators
{
    public class UpdateLeaveTypeDTOValidators : AbstractValidator<UpdateLeaveTypeDTO>
    {
        public UpdateLeaveTypeDTOValidators()
        {
            Include(new LeaveTypeValidators());
            RuleFor(p => p.Id)
                .NotNull().WithMessage("{PropertyNmae} Must Not Be Null");
        }
    }
}