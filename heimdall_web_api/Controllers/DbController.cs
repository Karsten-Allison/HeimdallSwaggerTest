using heimdall_web_api.Data;
using heimdall_web_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace heimdall_web_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DbController : Controller
    {
        private readonly WorkInstructionDatabaseContext context;

        public DbController(WorkInstructionDatabaseContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWorkInstructionSets()
        {

            return Ok(await context.workInstructionSets.ToListAsync());

        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetWorkInstructionSet([FromRoute] Guid id)
        {
            var workInSet = await context.workInstructionSets.FindAsync(id);

            if(workInSet != null)
            {               
                return Ok(workInSet);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddWorkInstructionSets(AddWorkInstructionRequest addWorkInstructionRequest)
        {
            var workInstructionSet = new WorkInstructionSet()
            {
                Id = Guid.NewGuid(),
                Title = addWorkInstructionRequest.Title,
                Description = addWorkInstructionRequest.Description,
                InstructionList = addWorkInstructionRequest.InstructionList,
            };

            await context.workInstructionSets.AddAsync(workInstructionSet);
            await context.SaveChangesAsync();

            return Ok(workInstructionSet);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateInstructionSet([FromRoute] Guid id, UpdateWorkInstructionRequest updateWorkInstructionRequest)
        {
            var workInSet = await context.workInstructionSets.FindAsync(id);

            if(workInSet != null)
            {
                workInSet.Title = updateWorkInstructionRequest.Title;
                workInSet.Description = updateWorkInstructionRequest.Description;
                workInSet.InstructionList = updateWorkInstructionRequest.InstructionList;

                await context.SaveChangesAsync();

                return Ok(workInSet);
            }

            return NotFound();

        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteWorkInstructionSet([FromRoute] Guid id)
        {
            var workInSet = await context.workInstructionSets.FindAsync(id);

            if (workInSet != null)
            {
                context.Remove(workInSet);
                await context.SaveChangesAsync();
                return Ok(workInSet);
            }

            return NotFound();
        }

    }
}
