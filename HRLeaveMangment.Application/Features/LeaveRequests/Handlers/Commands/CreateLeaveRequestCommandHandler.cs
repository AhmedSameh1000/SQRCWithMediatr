using AutoMapper;
using HrLeaveMangment.Domain;
using HRLeaveMangment.Application.Contracts.Infrastructure;
using HRLeaveMangment.Application.Contracts.persistence;
using HRLeaveMangment.Application.DTOs.LeaveRequests.Validators;
using HRLeaveMangment.Application.Features.LeaveRequests.Requests.Commands;
using HRLeaveMangment.Application.Models;
using HRLeaveMangment.Application.Response;
using MediatR;

namespace HRLeaveMangment.Application.Features.LeaveRequests.Handlers.Commands
{
    public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, BaseCommandResponse>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;

        public CreateLeaveRequestCommandHandler(
            ILeaveTypeRepository leaveTypeRepository,
            ILeaveRequestRepository leaveRequestRepository
            , IMapper mapper, IEmailSender emailSender)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
            _emailSender = emailSender;
        }

        public async Task<BaseCommandResponse> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var Response = new BaseCommandResponse();
            var Validator = new CreateLeaveRequestValidators(_leaveTypeRepository);
            var Result = await Validator.ValidateAsync(request.LeaveRequestDto);

            if (!Result.IsValid)
            {
                Response.Success = false;
                Response.Message = "Creation Failed";
                Response.Errors = Result.Errors.Select(c => c.ErrorMessage).ToList();

                return Response;
            }

            var LeaveRequest = _mapper.Map<LeaveRequest>(request.LeaveRequestDto);

            LeaveRequest = await _leaveRequestRepository.CreateAsync(LeaveRequest);

            Response.Success = true;
            Response.Message = "Creation Succesfuly";
            Response.Id = LeaveRequest.Id;

            var email = new Email
            {
                To = "emaployee@org.com",
                Body = $"your Leave Request For {request.LeaveRequestDto.StartDate} to {request.LeaveRequestDto.EndDate} " +
                $"has been submitted succesfuly",
                Subject = "Leave Request Submitted"
            };
            try
            {
                await _emailSender.SendEmail(email);
            }
            catch (Exception ex)
            {
                throw;
            }
            return Response;
        }
    }
}