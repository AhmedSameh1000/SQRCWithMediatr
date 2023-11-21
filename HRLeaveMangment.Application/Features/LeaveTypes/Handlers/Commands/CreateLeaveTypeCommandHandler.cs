using AutoMapper;
using HrLeaveMangment.Domain;
using HRLeaveMangment.Application.Contracts.persistence;
using HRLeaveMangment.Application.DTOs.LeaveTypes.Validators;
using HRLeaveMangment.Application.Features.LeaveTypes.Requestes.Commands;
using HRLeaveMangment.Application.Response;
using MediatR;

namespace HRLeaveMangment.Application.Features.LeaveTypes.Handlers.Commands
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, BaseCommandResponse>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public CreateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var Response = new BaseCommandResponse();
            var Validator = new CreateLeaveTypeDTOValidators();

            var Result = await Validator.ValidateAsync(request.CreateLeaveType);

            if (!Result.IsValid)
            {
                Response.Success = false;
                Response.Message = "Creation Failed";
                Response.Errors = Result.Errors.Select(c => c.ErrorMessage).ToList();

                return Response;
            }

            var leaveType = _mapper.Map<LeaveType>(request.CreateLeaveType);
            leaveType = await _leaveTypeRepository.CreateAsync(leaveType);

            Response.Success = true;
            Response.Message = "Creation Succesfuly";
            Response.Id = leaveType.Id;
            return Response;
        }
    }
}