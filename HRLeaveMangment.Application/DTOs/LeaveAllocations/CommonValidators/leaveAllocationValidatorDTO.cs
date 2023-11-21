using FluentValidation;
using HRLeaveMangment.Application.Contracts.persistence;

namespace HRLeaveMangment.Application.DTOs.LeaveAllocations.CommonValidators
{
    internal class leaveAllocationValidatorDTO : AbstractValidator<IleaveAllocationDTO>
    {
        private readonly ILeaveALLocationRepository _leaveALLocationRepository;

        public leaveAllocationValidatorDTO(ILeaveALLocationRepository leaveALLocationRepository)
        {
            _leaveALLocationRepository = leaveALLocationRepository;
            RuleFor(c => c.NumberOfDays)
                .GreaterThan(0).WithMessage("{PropertyName} Must Be More Than 0")
                .LessThan(100).WithMessage("{PropertyName} Must Be Less Than 100");

            RuleFor(c => c.LeaveTypeId)
                .GreaterThan(0)
                .MustAsync(async (id, token) =>
                {
                    var Exist = await _leaveALLocationRepository.Exist(id);
                    return !Exist;
                }).WithMessage("{PropertyName} Not E xist");
        }
    }
}