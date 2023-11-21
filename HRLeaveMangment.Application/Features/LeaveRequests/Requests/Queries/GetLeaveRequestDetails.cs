using HRLeaveMangment.Application.DTOs.LeaveRequests;
using MediatR;

namespace HRLeaveMangment.Application.Features.LeaveRequests.Requests.Queries
{
    public class GetLeaveRequestDetails : IRequest<LeaveRequestDto>
    {
        public int Id { get; set; }
    }
}