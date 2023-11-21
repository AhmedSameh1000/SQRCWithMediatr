using AutoMapper;
using HRLeaveMangment.Application.Contracts.persistence;
using HRLeaveMangment.Application.DTOs.LeaveTypes.Validators;
using HRLeaveMangment.Application.Exceptions;
using HRLeaveMangment.Application.Features.LeaveTypes.Requestes.Commands;
using MediatR;

namespace HRLeaveMangment.Application.Features.LeaveTypes.Handlers.Commands
{
    public class UpdateLeaveTypeHandler : IRequestHandler<UpdateLeaveTypeCommand>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public UpdateLeaveTypeHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var Validator = new UpdateLeaveTypeDTOValidators();

            var Result = await Validator.ValidateAsync(request.UpdateLeaveTypeDTO);

            if (!Result.IsValid)
                throw new ValidationException(Result);

            var LeaveType = await _leaveTypeRepository.GetAsync(request.UpdateLeaveTypeDTO.Id);

            var res = _mapper.Map(request.UpdateLeaveTypeDTO, LeaveType);

            await _leaveTypeRepository.UpdateAsync(res);
        }
    }
}