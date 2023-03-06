using Heimdall.Logic.Core;
using Heimdall.Logic.WorkInstructions.Commands;
using Heimdall.Logic.WorkInstructions.Events;
using OneOf;

namespace Heimdall.Logic.WorkInstructions
{
    /// <summary>
    /// Implementation of commands that result in changes to Work Instructions.
    /// </summary>
    public interface IWorkInstructionLogic
    {
        Task<OneOf<WorkInstructionCreated, CreateWorkInstructionFailed>> AddAsync(CreateWorkInstruction command);

        Task<OneOf<InstructionCreated, CreateInstructionFailed>> AddAsyncInstruction(CreateInstruction command, int ForeignKeyID);
        Task<OneOf<WorkInstructionDeleted, DeleteWorkInstructionFailed>> DeleteAsync(DeleteWorkInstruction command);
        Task<OneOf<WorkInstructionsRead, WorkInstructionNotFound>> GetAllAsync();
        Task<OneOf<WorkInstructionRead, WorkInstructionNotFound>> GetAsync(ReadWorkInstruction command);
        Task<OneOf<WorkInstructionUpdated, UpdateWorkInstructionFailed>> UpdateAsync(UpdateWorkInstruction command);
    }
}
