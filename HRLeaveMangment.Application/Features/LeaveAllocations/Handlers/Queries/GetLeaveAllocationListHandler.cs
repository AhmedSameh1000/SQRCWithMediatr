using AutoMapper;
using HRLeaveMangment.Application.Contracts.persistence;
using HRLeaveMangment.Application.DTOs.LeaveAllocations;
using HRLeaveMangment.Application.Features.LeaveAllocations.Requests.Queries;
using MediatR;

namespace HRLeaveMangment.Application.Features.LeaveAllocations.Handlers.Queries
{
    public class GetLeaveAllocationListHandler : IRequestHandler<GetLeaveAllocationDetailsRequest, LeaveAllocationDto>
    {
        private readonly ILeaveALLocationRepository _leaveALLocationRepository;
        private readonly IMapper _mapper;

        public GetLeaveAllocationListHandler(ILeaveALLocationRepository leaveALLocationRepository, IMapper mapper)
        {
            _leaveALLocationRepository = leaveALLocationRepository;
            _mapper = mapper;
        }

        public async Task<LeaveAllocationDto> Handle(GetLeaveAllocationDetailsRequest request, CancellationToken cancellationToken)
        {
            var LeaveAllocation = await _leaveALLocationRepository.GetAsync(request.Id);

            return _mapper.Map<LeaveAllocationDto>(LeaveAllocation);
        }
    }
}