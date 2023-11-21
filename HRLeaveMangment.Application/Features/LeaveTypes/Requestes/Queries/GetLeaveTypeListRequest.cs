using HRLeaveMangment.Application.DTOs.LeaveTypes;
using MediatR;

namespace HRLeaveMangment.Application.Features.LeaveTypes.Requestes.Queries
{
    public class GetLeaveTypeListRequest : IRequest<List<LeaveTypeDto>>
    {
    }
}