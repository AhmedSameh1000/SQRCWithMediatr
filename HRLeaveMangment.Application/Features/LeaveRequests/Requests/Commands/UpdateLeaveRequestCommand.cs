using HRLeaveMangment.Application.DTOs.LeaveRequests;
using HRLeaveMangment.Application.Response;
using MediatR;

namespace HRLeaveMangment.Application.Features.LeaveRequests.Requests.Commands
{
    public class UpdateLeaveRequestCommand : IRequest<BaseCommandResponse>
    {
        public UpdateLeaveRequestDTO UpdateLeaveRequestDTO { get; set; }
    }
}