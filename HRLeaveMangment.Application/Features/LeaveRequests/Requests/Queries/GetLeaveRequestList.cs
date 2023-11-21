using HRLeaveMangment.Application.DTOs.LeaveRequests;
using MediatR;

namespace HRLeaveMangment.Application.Features.LeaveRequests.Requests.Queries
{
    public class GetLeaveRequestList : IRequest<List<LeaveRequestDto>>
    {
    }
}