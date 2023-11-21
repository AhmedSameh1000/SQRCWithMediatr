using HRLeaveMangment.Application.DTOs.LeaveTypes;
using HRLeaveMangment.Application.Response;
using MediatR;

namespace HRLeaveMangment.Application.Features.LeaveTypes.Requestes.Commands
{
    public class CreateLeaveTypeCommand : IRequest<BaseCommandResponse>
    {
        public CreateLeaveTypeDto CreateLeaveType { get; set; }
    }
}