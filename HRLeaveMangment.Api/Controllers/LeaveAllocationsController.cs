using HRLeaveMangment.Application.DTOs.LeaveAllocations;
using HRLeaveMangment.Application.Features.LeaveAllocations.Requests.Commands;
using HRLeaveMangment.Application.Features.LeaveAllocations.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HRLeaveMangment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveAllocationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveAllocationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<LeaveTypeController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var LeaveTypes = await _mediator.Send(new GetLeaveAllocationListRequest());

            return Ok(LeaveTypes);
        }

        // GET api/<LeaveTypeController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var LeaveType = await _mediator.Send(new GetLeaveAllocationDetailsRequest() { Id = id });

            return Ok(LeaveType);
        }

        // POST api/<LeaveTypeController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateLeaveAllocationDTO createLeaveTypeDto)
        {
            var LeaveTypeCommand = await _mediator.Send(new CreateLeaveAllocationCommand() { LeaveAllocationDto = createLeaveTypeDto });

            return Ok(LeaveTypeCommand);
        }

        // PUT api/<LeaveTypeController>/5
        [HttpPut()]
        public async Task<IActionResult> Put([FromBody] UpdateLeaveAllocationDTO updateLeaveTypeDTO)
        {
            await _mediator.Send(new UpdateLeaveAllocationCommand() { UpdateLeaveAllocationDTO = updateLeaveTypeDTO });

            return Ok();
        }

        // DELETE api/<LeaveTypeController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteLeaveAllocationCommand() { Id = id });

            return Ok();
        }
    }
}