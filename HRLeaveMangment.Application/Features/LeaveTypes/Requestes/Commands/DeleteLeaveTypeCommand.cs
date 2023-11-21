using MediatR;

namespace HRLeaveMangment.Application.Features.LeaveTypes.Requestes.Commands
{
    public class DeleteLeaveTypeCommand : IRequest
    {
        public int Id { get; set; }
    }
}