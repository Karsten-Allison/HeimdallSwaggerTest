using heimdall_web_api.Models;
using Heimdall.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Heimdall.Logic.WorkInstructions.Commands;
using Heimdall.Logic.WorkInstructions;
using Heimdall.Logic.WorkInstructions.Events;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using OneOf.Types;

namespace heimdall_web_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkInstructionsController : Controller
    {
        private readonly IWorkInstructionLogic _logic;

        public WorkInstructionsController(IWorkInstructionLogic logic)
        {
            _logic = logic;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WorkInstructionRead))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(WorkInstructionNotFound))]
        public async Task<IActionResult> GetAllWorkInstructions()
        {
            var result = await _logic.GetAllAsync();
            return result.Match(
                read => (IActionResult)Ok(read),
                notFound => NotFound(notFound)
            );
        }

        [HttpGet]
        [Route("{Id}")] // RLP - has to be caps so it matches the object in the ReadWorkInstruction .
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WorkInstructionRead))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(WorkInstructionNotFound))]
        public async Task<IActionResult> GetWorkInstructions([FromRoute] ReadWorkInstruction command) // RLP - Entity framework is super smart.
        {
            var result = await _logic.GetAsync(command);
            return result.Match(
                read => (IActionResult)Ok(read),
                notFound => NotFound(notFound)
            );
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(WorkInstructionCreated))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CreateWorkInstructionFailed))]
        public async Task<IActionResult> AddWorkInstructions([FromBody] CreateWorkInstruction command)
        {
            var result = await _logic.AddAsync(command);
            return result.Match(
                success => (IActionResult)Ok(success),
                error => Problem(detail: error.Reason, title: "Failed to Add Work Instructions", type: error.GetType().Name)
            );
        }

        [HttpPost]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(InstructionCreated))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CreateInstructionFailed))]
        public async Task<IActionResult> AddInstructions([FromRoute] int id, [FromBody] CreateInstruction request)
        {
            var command = request with { ForeignKeyId = id };
            var result = await _logic.AddAsyncInstruction(command);
            return result.Match(
                success => (IActionResult)Ok(success),
                error => Problem(detail: error.Reason, title: "Failed to Add Work Instructions", type: error.GetType().Name)
            );
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateWorkInstruction([FromRoute] int id, [FromBody] UpdateWorkInstruction request)
        {
            var command = request with { Id = id };
            var result = await _logic.UpdateAsync(command);
            return result.Match(
                success => (IActionResult)Ok(success),
                error => Problem(detail: error.Reason, title: "Failed to Update Work Instructions", type: error.GetType().Name)
            );
        }

        [HttpPut]
        [Route("{id}/{id2}")]
        public async Task<IActionResult> UpdateInstruction([FromRoute] int id, [FromRoute] int id2, [FromBody] UpdateInstruction request)
        {
            var command = request with { Id = id, InstructionID = id2 };
            var result = await _logic.UpdateAsyncInstruction(command);
            return result.Match(
                success => (IActionResult)Ok(success),
                error => Problem(detail: error.Reason, title: "Failed to Update Instruction", type: error.GetType().Name)
            );
        }

        [HttpDelete]
        [Route("{Id}")]
        public async Task<IActionResult> DeleteWorkInstruction([FromRoute] DeleteWorkInstruction command)
        {
            var result = await _logic.DeleteAsync(command);
            return result.Match(
                success => (IActionResult)Ok(success),
                notFound => NotFound(notFound)
            );
        }

        [HttpDelete]
        [Route("{id}/{id2}")]
        public async Task<IActionResult> DeleteInstruction([FromRoute] int id, [FromRoute] int id2, [FromBody] DeleteInstruction request)
        {
            var command = request with { Id = id, InstructionID = id2 };
            var result = await _logic.DeleteAsyncInstruction(command);
            return result.Match(
                success => (IActionResult)Ok(success),
                error => Problem(detail: error.Reason, title: "Failed to Update Instruction", type: error.GetType().Name)
            );
        }

    }
}
