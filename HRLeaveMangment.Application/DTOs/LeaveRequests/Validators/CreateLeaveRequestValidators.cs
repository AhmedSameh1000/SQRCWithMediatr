using FluentValidation;
using HRLeaveMangment.Application.Contracts.persistence;
using HRLeaveMangment.Application.DTOs.LeaveRequests.CommonValidators;

namespace HRLeaveMangment.Application.DTOs.LeaveRequests.Validators
{
    public class CreateLeaveRequestValidators : AbstractValidator<CreateLeaveRequestDTO>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveRequestValidators(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
            Include(new LeaveRequestValidators(_leaveTypeRepository));
        }
    }
}