using HRLeaveMangment.Application.Contracts.persistence;
using HRLeaveMangment.Application.Exceptions;
using HRLeaveMangment.Application.Features.LeaveAllocations.Requests.Commands;
using MediatR;

namespace HRLeaveMangment.Application.Features.LeaveAllocations.Handlers.Commands
{
    public class DeleteLeaveAllocationCommandHandler : IRequestHandler<DeleteLeaveAllocationCommand>
    {
        private readonly ILeaveALLocationRepository _leaveALLocationRepository;

        public DeleteLeaveAllocationCommandHandler(ILeaveALLocationRepository leaveALLocationRepository)
        {
            _leaveALLocationRepository = leaveALLocationRepository;
        }

        public async Task Handle(DeleteLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var LeaveAllocation = await _leaveALLocationRepository.GetAsync(request.Id);

            if (LeaveAllocation == null)
            {
                throw new NotFoundException("Not Found", request.Id);
            }

            await _leaveALLocationRepository.DeleteAsync(LeaveAllocation);
        }
    }
}