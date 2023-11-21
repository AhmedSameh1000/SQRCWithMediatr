using AutoMapper;
using HrLeaveMangment.Domain;
using HRLeaveMangment.Application.DTOs.LeaveAllocations;
using HRLeaveMangment.Application.DTOs.LeaveRequests;
using HRLeaveMangment.Application.DTOs.LeaveTypes;

namespace HRLeaveMangment.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LeaveRequest, LeaveRequestDto>().ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestListDTO>().ReverseMap();
            CreateMap<LeaveRequest, UpdateLeaveRequestDTO>().ReverseMap();
            CreateMap<LeaveRequest, CreateLeaveRequestDTO>().ReverseMap();
            CreateMap<LeaveRequest, ChangeLeaveRequestApprovalDTO>().ReverseMap();
            //////
            CreateMap<LeaveType, LeaveTypeDto>().ReverseMap();
            CreateMap<LeaveType, CreateLeaveTypeDto>().ReverseMap();
            CreateMap<LeaveType, UpdateLeaveTypeDTO>().ReverseMap();

            //////////
            CreateMap<LeaveAllocation, LeaveAllocationDto>().ReverseMap();
            CreateMap<LeaveAllocation, UpdateLeaveAllocationDTO>().ReverseMap();
            CreateMap<LeaveAllocation, CreateLeaveAllocationDTO>().ReverseMap();
        }
    }
}