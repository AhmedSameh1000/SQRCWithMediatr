using FluentValidation;
using HRLeaveMangment.Application.Contracts.persistence;
using HRLeaveMangment.Application.DTOs.LeaveRequests.CommonValidators;

namespace HRLeaveMangment.Application.DTOs.LeaveRequests.Validators
{
    public class UpdateLeaveRequestDTOValidators : AbstractValidator<UpdateLeaveRequestDTO>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public UpdateLeaveRequestDTOValidators(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;

            Include(new LeaveRequestValidators(_leaveTypeRepository));
            RuleFor(c => c.Id)
                .NotNull().WithMessage("name MustNot Be Null");
        }
    }
}