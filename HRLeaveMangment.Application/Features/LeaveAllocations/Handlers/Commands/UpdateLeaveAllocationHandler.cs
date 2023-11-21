using AutoMapper;
using HRLeaveMangment.Application.Contracts.persistence;
using HRLeaveMangment.Application.DTOs.LeaveAllocations.Validators;
using HRLeaveMangment.Application.Exceptions;
using HRLeaveMangment.Application.Features.LeaveAllocations.Requests.Commands;
using MediatR;

namespace HRLeaveMangment.Application.Features.LeaveAllocations.Handlers.Commands
{
    public class UpdateLeaveAllocationHandler : IRequestHandler<UpdateLeaveAllocationCommand>
    {
        private readonly ILeaveALLocationRepository _leaveALLocationRepository;
        private readonly IMapper _mapper;

        public UpdateLeaveAllocationHandler(ILeaveALLocationRepository leaveALLocationRepository, IMapper mapper)
        {
            _leaveALLocationRepository = leaveALLocationRepository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var Validator = new UpdateLeaveAllocationValidators(_leaveALLocationRepository);

            var Result = await Validator.ValidateAsync(request.UpdateLeaveAllocationDTO);

            if (!Result.IsValid)
            {
                throw new ValidationException(Result);
            }

            var LeaveRequest = _leaveALLocationRepository.GetAsync(request.UpdateLeaveAllocationDTO.Id);

            var res = await _mapper.Map(request.UpdateLeaveAllocationDTO, LeaveRequest);

            await _leaveALLocationRepository.UpdateAsync(res);
        }
    }
}