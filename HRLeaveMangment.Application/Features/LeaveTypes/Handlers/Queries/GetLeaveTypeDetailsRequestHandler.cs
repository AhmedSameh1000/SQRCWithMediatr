using AutoMapper;
using HRLeaveMangment.Application.Contracts.persistence;
using HRLeaveMangment.Application.DTOs.LeaveTypes;
using HRLeaveMangment.Application.Features.LeaveTypes.Requestes.Queries;
using MediatR;

namespace HRLeaveMangment.Application.Features.LeaveTypes.Handlers.Queries
{
    public class GetLeaveTypeDetailsRequestHandler : IRequestHandler<GetLeaveTypeDetailsRequest, LeaveTypeDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public GetLeaveTypeDetailsRequestHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<LeaveTypeDto> Handle(GetLeaveTypeDetailsRequest request, CancellationToken cancellationToken)
        {
            var LeaveType = await _leaveTypeRepository.GetAsync(request.Id);

            return _mapper.Map<LeaveTypeDto>(LeaveType);
        }
    }
}