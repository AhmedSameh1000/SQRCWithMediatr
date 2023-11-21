using HRLeaveMangment.Application.DTOs.LeaveTypes;
using MediatR;

namespace HRLeaveMangment.Application.Features.LeaveTypes.Requestes.Queries
{
    public class GetLeaveTypeDetailsRequest : IRequest<LeaveTypeDto>
    {
        public int Id { get; set; }
    }
}