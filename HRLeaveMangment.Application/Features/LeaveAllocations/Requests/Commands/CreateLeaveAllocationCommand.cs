using HRLeaveMangment.Application.DTOs.LeaveAllocations;
using MediatR;

namespace HRLeaveMangment.Application.Features.LeaveAllocations.Requests.Commands
{
    public class CreateLeaveAllocationCommand : IRequest<int>
    {
        public CreateLeaveAllocationDTO LeaveAllocationDto { get; set; }
    }
}