using AutoMapper;
using HRLeaveMangment.Application.Contracts.persistence;
using HRLeaveMangment.Application.DTOs.LeaveRequests;
using HRLeaveMangment.Application.Features.LeaveRequests.Requests.Queries;
using MediatR;

namespace HRLeaveMangment.Application.Features.LeaveRequests.Handlers.Queries
{
    public class GetLeaveRequestListHandler : IRequestHandler<GetLeaveRequestList, List<LeaveRequestDto>>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public GetLeaveRequestListHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }

        public async Task<List<LeaveRequestDto>> Handle(GetLeaveRequestList request, CancellationToken cancellationToken)
        {
            var LeaveRequests = await _leaveRequestRepository.GetAllAsync();
            return _mapper.Map<List<LeaveRequestDto>>(LeaveRequests);
        }
    }
}