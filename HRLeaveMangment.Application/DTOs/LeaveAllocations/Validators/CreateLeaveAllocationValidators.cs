using FluentValidation;
using HRLeaveMangment.Application.Contracts.persistence;
using HRLeaveMangment.Application.DTOs.LeaveAllocations.CommonValidators;

namespace HRLeaveMangment.Application.DTOs.LeaveAllocations.Validators
{
    public class CreateLeaveAllocationValidators : AbstractValidator<CreateLeaveAllocationDTO>
    {
        private readonly ILeaveALLocationRepository _leaveALLocationRepository;

        public CreateLeaveAllocationValidators(ILeaveALLocationRepository leaveALLocationRepository)
        {
            _leaveALLocationRepository = leaveALLocationRepository;
            Include(new leaveAllocationValidatorDTO(_leaveALLocationRepository));
        }
    }
}