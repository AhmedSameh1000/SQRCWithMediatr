using HRLeaveMangment.Application.Contracts.persistence;
using HRLeaveMangment.Application.Exceptions;
using HRLeaveMangment.Application.Features.LeaveTypes.Requestes.Commands;
using MediatR;

namespace HRLeaveMangment.Application.Features.LeaveTypes.Handlers.Commands
{
    public class DeleteLeavetTypeCommandhealper : IRequestHandler<DeleteLeaveTypeCommand>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public DeleteLeavetTypeCommandhealper(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
        }

        public async Task Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var LeaveType = await _leaveTypeRepository.GetAsync(request.Id);
            if (LeaveType is null)
            {
                throw new NotFoundException(nameof(LeaveType), request.Id);
            }

            await _leaveTypeRepository.DeleteAsync(LeaveType);
        }
    }
}