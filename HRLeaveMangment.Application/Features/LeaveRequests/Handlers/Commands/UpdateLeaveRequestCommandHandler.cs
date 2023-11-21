using AutoMapper;
using HRLeaveMangment.Application.Contracts.Infrastructure;
using HRLeaveMangment.Application.Contracts.persistence;
using HRLeaveMangment.Application.DTOs.LeaveRequests.Validators;
using HRLeaveMangment.Application.Features.LeaveRequests.Requests.Commands;
using HRLeaveMangment.Application.Response;
using MediatR;

namespace HRLeaveMangment.Application.Features.LeaveRequests.Handlers.Commands
{
    public class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommand, BaseCommandResponse>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;

        public UpdateLeaveRequestCommandHandler(
            ILeaveTypeRepository leaveTypeRepository,
            ILeaveRequestRepository leaveRequestRepository
            , IMapper mapper,
            IEmailSender emailSender)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
            _emailSender = emailSender;
        }

        public async Task<BaseCommandResponse> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var Response = new BaseCommandResponse();
            var Validator = new UpdateLeaveRequestDTOValidators(_leaveTypeRepository);
            var Result = await Validator.ValidateAsync(request.UpdateLeaveRequestDTO);

            if (!Result.IsValid)
            {
                Response.Success = false;
                Response.Message = "Update Failed";
                Response.Errors = Result.Errors.Select(c => c.ErrorMessage).ToList();
                return Response;
            }
            var LeaveRequest = _leaveRequestRepository.GetAsync(request.UpdateLeaveRequestDTO.Id);

            var LeaveMapper = await _mapper.Map(request.UpdateLeaveRequestDTO, LeaveRequest);

            var LeaveUpdated = _leaveRequestRepository.UpdateAsync(LeaveMapper);
            Response.Success = true;
            Response.Message = "Update Successfuly";
            Response.Id = LeaveUpdated.Id;
            return Response;
        }
    }
}