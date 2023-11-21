using HRLeaveMangment.Application.DTOs.LeaveTypes;
using MediatR;

namespace HRLeaveMangment.Application.Features.LeaveTypes.Requestes.Commands
{
    public class UpdateLeaveTypeCommand : IRequest
    {
        public UpdateLeaveTypeDTO UpdateLeaveTypeDTO { get; set; }
    }
}