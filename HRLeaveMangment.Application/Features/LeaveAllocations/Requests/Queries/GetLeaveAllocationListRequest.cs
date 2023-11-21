using HRLeaveMangment.Application.DTOs.LeaveAllocations;
using MediatR;

namespace HRLeaveMangment.Application.Features.LeaveAllocations.Requests.Queries
{
    public class GetLeaveAllocationListRequest : IRequest<List<LeaveAllocationDto>>
    {
    }
}