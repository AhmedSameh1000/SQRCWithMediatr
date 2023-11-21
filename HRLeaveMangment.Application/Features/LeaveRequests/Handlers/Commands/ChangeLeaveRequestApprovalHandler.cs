using AutoMapper;
using HrLeaveMangment.Domain;
using HRLeaveMangment.Application.Contracts.persistence;
using HRLeaveMangment.Application.Features.LeaveRequests.Requests.Commands;
using MediatR;

namespace HRLeaveMangment.Application.Features.LeaveRequests.Handlers.Commands
{
    public class ChangeLeaveRequestApprovalHandler : IRequestHandler<UpdateLeaveRequestApprovalCommand, LeaveRequest>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public ChangeLeaveRequestApprovalHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }

        public async Task<LeaveRequest> Handle(UpdateLeaveRequestApprovalCommand request, CancellationToken cancellationToken)
        {
            var Leave = await _leaveRequestRepository.GetAsync(request.ChangeLeaveRequestApproval.Id);
            Leave = _mapper.Map(request.ChangeLeaveRequestApproval, Leave);
            await _leaveRequestRepository.UpdateAsync(Leave);
            return Leave;
        }
    }
}