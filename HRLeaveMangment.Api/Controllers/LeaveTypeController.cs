using HRLeaveMangment.Application.DTOs.LeaveTypes;
using HRLeaveMangment.Application.Features.LeaveTypes.Requestes.Commands;
using HRLeaveMangment.Application.Features.LeaveTypes.Requestes.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HRLeaveMangment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<LeaveTypeController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var LeaveTypes = await _mediator.Send(new GetLeaveTypeListRequest());

            return Ok(LeaveTypes);
        }

        // GET api/<LeaveTypeController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var LeaveType = await _mediator.Send(new GetLeaveTypeDetailsRequest() { Id = id });

            return Ok(LeaveType);
        }

        // POST api/<LeaveTypeController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateLeaveTypeDto createLeaveTypeDto)
        {
            var LeaveTypeCommand = await _mediator.Send(new CreateLeaveTypeCommand() { CreateLeaveType = createLeaveTypeDto });

            return Ok(LeaveTypeCommand);
        }

        // PUT api/<LeaveTypeController>/5
        [HttpPut()]
        public async Task<IActionResult> Put([FromBody] UpdateLeaveTypeDTO updateLeaveTypeDTO)
        {
            await _mediator.Send(new UpdateLeaveTypeCommand() { UpdateLeaveTypeDTO = updateLeaveTypeDTO });

            return Ok();
        }

        // DELETE api/<LeaveTypeController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteLeaveTypeCommand() { Id = id });

            return Ok();
        }
    }
}