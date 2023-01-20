using Heimdall.Logic.Core;
using Heimdall.Logic.WorkInstructions.Commands;
using Heimdall.Logic.WorkInstructions.Entities;
using Heimdall.Logic.WorkInstructions.Events;
using OneOf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heimdall.Logic.WorkInstructions
{
    // RLP - By specifying an accessor interface, the Logic assembly only needs to specify
    // behaviors that must exist, not how they work. That detail be left to the Data assembly.
    public interface IWorkInstructionAccessor
    {
        Task<OneOf<WorkInstructionRead, WorkInstructionNotFound>> GetAsync(ReadWorkInstruction command);

        Task<OneOf<WorkInstructionsRead, WorkInstructionNotFound>> GetAllAsync();

        Task<OneOf<WorkInstructionCreated, CreateWorkInstructionFailed>> AddAsync(CreateWorkInstruction command);

        Task<OneOf<WorkInstructionUpdated, UpdateWorkInstructionFailed>> UpdateAsync(UpdateWorkInstruction command);

        Task<OneOf<WorkInstructionDeleted, DeleteWorkInstructionFailed>> DeleteAsync(DeleteWorkInstruction command);
    }
}
