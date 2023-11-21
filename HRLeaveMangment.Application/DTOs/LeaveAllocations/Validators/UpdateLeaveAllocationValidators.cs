using FluentValidation;
using HRLeaveMangment.Application.Contracts.persistence;
using HRLeaveMangment.Application.DTOs.LeaveAllocations.CommonValidators;

namespace HRLeaveMangment.Application.DTOs.LeaveAllocations.Validators
{
    internal class UpdateLeaveAllocationValidators : AbstractValidator<UpdateLeaveAllocationDTO>
    {
        private readonly ILeaveALLocationRepository _leaveALLocationRepository;

        public UpdateLeaveAllocationValidators(ILeaveALLocationRepository leaveALLocationRepository)
        {
            _leaveALLocationRepository = leaveALLocationRepository;
            Include(new leaveAllocationValidatorDTO(_leaveALLocationRepository));
            RuleFor(c => c.Id)
                .NotNull().WithMessage("{PropertyName} Must Not Be Null");
        }
    }
}