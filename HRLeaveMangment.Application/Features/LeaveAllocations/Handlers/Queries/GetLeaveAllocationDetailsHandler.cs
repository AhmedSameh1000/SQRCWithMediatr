using AutoMapper;
using HRLeaveMangment.Application.Contracts.persistence;
using HRLeaveMangment.Application.DTOs.LeaveAllocations;
using HRLeaveMangment.Application.Features.LeaveAllocations.Requests.Queries;
using MediatR;

namespace HRLeaveMangment.Application.Features.LeaveAllocations.Handlers.Queries
{
    public class GetLeaveAllocationDetailsHandler : IRequestHandler<GetLeaveAllocationListRequest, List<LeaveAllocationDto>>
    {
        private readonly ILeaveALLocationRepository _leaveALLocationRepository;
        private readonly IMapper _mapper;

        public GetLeaveAllocationDetailsHandler(ILeaveALLocationRepository leaveALLocationRepository, IMapper mapper)
        {
            _leaveALLocationRepository = leaveALLocationRepository;
            _mapper = mapper;
        }

        public async Task<List<LeaveAllocationDto>> Handle(GetLeaveAllocationListRequest request, CancellationToken cancellationToken)
        {
            var LeavesAllocations = await _leaveALLocationRepository.GetAllAsync();

            return _mapper.Map<List<LeaveAllocationDto>>(LeavesAllocations);
        }
    }
}