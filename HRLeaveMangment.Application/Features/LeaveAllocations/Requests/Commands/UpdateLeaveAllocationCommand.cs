using HRLeaveMangment.Application.DTOs.LeaveAllocations;
using MediatR;

namespace HRLeaveMangment.Application.Features.LeaveAllocations.Requests.Commands
{
    public class UpdateLeaveAllocationCommand : IRequest
    {
        public UpdateLeaveAllocationDTO UpdateLeaveAllocationDTO { get; set; }
    }
}