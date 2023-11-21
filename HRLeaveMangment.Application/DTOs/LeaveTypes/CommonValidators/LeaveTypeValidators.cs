using FluentValidation;

namespace HRLeaveMangment.Application.DTOs.LeaveTypes.CommonValidators
{
    public class LeaveTypeValidators : AbstractValidator<ILeaveTypeDTO>
    {
        public LeaveTypeValidators()
        {
            Validate();
        }

        public void Validate()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("The Name Value Must be not Empty")
                .NotNull().WithMessage("Not be Null")
                .MaximumLength(50).WithMessage("Must not Be more than 50 character");

            RuleFor(p => p.defaultDays)
                .NotEmpty().WithMessage("{PropertyName} Must Not Be Empty")
                .NotNull().WithMessage("{PropertyName} Not be Null")
                .GreaterThan(0).WithMessage("{PropertyName} More Than 1")
                .LessThan(100).WithMessage("{PropertyName} Less than 100");
        }
    }
}