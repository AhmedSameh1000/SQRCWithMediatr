using HRLeaveMangment.Application.DTOs.LeaveRequests;
using HRLeaveMangment.Application.Response;
using MediatR;

namespace HRLeaveMangment.Application.Features.LeaveRequests.Requests.Commands
{
    public class CreateLeaveRequestCommand : IRequest<BaseCommandResponse>
    {
        public CreateLeaveRequestDTO LeaveRequestDto { get; set; }
    }
}