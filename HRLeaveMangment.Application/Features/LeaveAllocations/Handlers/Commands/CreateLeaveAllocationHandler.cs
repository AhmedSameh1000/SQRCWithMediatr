using AutoMapper;
using HrLeaveMangment.Domain;
using HRLeaveMangment.Application.Contracts.persistence;
using HRLeaveMangment.Application.DTOs.LeaveAllocations.Validators;
using HRLeaveMangment.Application.Exceptions;
using HRLeaveMangment.Application.Features.LeaveAllocations.Requests.Commands;
using MediatR;

namespace HRLeaveMangment.Application.Features.LeaveAllocations.Handlers.Commands
{
    public class CreateLeaveAllocationHandler : IRequestHandler<CreateLeaveAllocationCommand, int>
    {
        private readonly ILeaveALLocationRepository _leaveALLocationRepository;
        private readonly IMapper _mapper;

        public CreateLeaveAllocationHandler(ILeaveALLocationRepository leaveALLocationRepository, IMapper mapper)
        {
            _leaveALLocationRepository = leaveALLocationRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var Validator = new CreateLeaveAllocationValidators(_leaveALLocationRepository);

            var Result = await Validator.ValidateAsync(request.LeaveAllocationDto);

            if (!Result.IsValid)
            {
                throw new ValidationException(Result);
            }

            var LeaveAllocation = _mapper.Map<LeaveAllocation>(request.LeaveAllocationDto);

            LeaveAllocation = await _leaveALLocationRepository.CreateAsync(LeaveAllocation);
            return LeaveAllocation.Id;
        }
    }
}