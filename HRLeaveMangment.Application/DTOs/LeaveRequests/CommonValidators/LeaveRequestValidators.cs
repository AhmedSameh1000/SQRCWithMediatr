using FluentValidation;
using HRLeaveMangment.Application.Contracts.persistence;

namespace HRLeaveMangment.Application.DTOs.LeaveRequests.CommonValidators
{
    public class LeaveRequestValidators : AbstractValidator<ILeaveRequestValidators>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public LeaveRequestValidators(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;

            RuleFor(p => p.StartDate)
                .LessThan(p => p.EndDate).WithMessage("{PropertyName} Must Be Before {ComparisonValue}");

            RuleFor(p => p.EndDate)
                .GreaterThan(p => p.StartDate).WithMessage("{PropertyName} Must Be after {ComparisonValue}");

            RuleFor(p => p.LeaveTypeId)
                .GreaterThan(0)
                .MustAsync(async (id, token) =>
                {
                    var LeaveTypeExist = await _leaveTypeRepository.Exist(id);
                    return !LeaveTypeExist;
                })
                .WithMessage("{PropertyName} Does Not Exist");
            _leaveTypeRepository = leaveTypeRepository;
        }
    }
}