using AutoMapper;
using HRLeaveMangment.Application.Contracts.persistence;
using HRLeaveMangment.Application.DTOs.LeaveRequests;
using HRLeaveMangment.Application.Features.LeaveRequests.Requests.Queries;
using MediatR;

namespace HRLeaveMangment.Application.Features.LeaveRequests.Handlers.Queries
{
    public class GetLeaveRequestDetailsHandler : IRequestHandler<GetLeaveRequestDetails, LeaveRequestDto>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public GetLeaveRequestDetailsHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }

        public async Task<LeaveRequestDto> Handle(GetLeaveRequestDetails request, CancellationToken cancellationToken)
        {
            var LeaveRequest = await _leaveRequestRepository.GetAsync(request.Id);

            return _mapper.Map<LeaveRequestDto>(LeaveRequest);
        }
    }
}