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
        [Route("{id}")]
        public async Task<IActionResult> GetWorkInstructionSet([FromRoute] int id)
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

                Title = addWorkInstructionRequest.Title,
                Description = addWorkInstructionRequest.Description,
                InstructionObject = addWorkInstructionRequest.InstructionObject,
            };

            await context.workInstructionSets.AddAsync(workInstructionSet);
            await context.SaveChangesAsync();

            return Ok(workInstructionSet);
        }
        
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateInstructionSet([FromRoute] int id, UpdateWorkInstructionRequest updateWorkInstructionRequest)
        {
            var workInSet = await context.workInstructionSets.FindAsync(id);

            if(workInSet != null)
            {
                workInSet.Title = updateWorkInstructionRequest.Title;
                workInSet.Description = updateWorkInstructionRequest.Description;
                workInSet.InstructionObject = updateWorkInstructionRequest.InstructionObject;

                await context.SaveChangesAsync();

                return Ok(workInSet);
            }

            return NotFound();

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteWorkInstructionSet(int id)
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
