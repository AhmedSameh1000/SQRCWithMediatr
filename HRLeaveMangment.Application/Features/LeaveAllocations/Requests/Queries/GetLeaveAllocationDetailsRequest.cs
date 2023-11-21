using HRLeaveMangment.Application.DTOs.LeaveAllocations;
using MediatR;

namespace HRLeaveMangment.Application.Features.LeaveAllocations.Requests.Queries
{
    public class GetLeaveAllocationDetailsRequest : IRequest<LeaveAllocationDto>
    {
        public int Id { get; set; }
    }
}