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
        // For WorkInstruction's
        Task<OneOf<WorkInstructionCreated, CreateWorkInstructionFailed>> AddAsync(CreateWorkInstruction command);
        Task<OneOf<WorkInstructionDeleted, DeleteWorkInstructionFailed>> DeleteAsync(DeleteWorkInstruction command);
        Task<OneOf<WorkInstructionsRead, WorkInstructionNotFound>> GetAllAsync();
        Task<OneOf<WorkInstructionRead, WorkInstructionNotFound>> GetAsync(ReadWorkInstruction command);
        Task<OneOf<WorkInstructionUpdated, UpdateWorkInstructionFailed>> UpdateAsync(UpdateWorkInstruction command);

        // For Instruction's
        Task<OneOf<InstructionDeleted, DeleteInstructionFailed>> DeleteAsyncInstruction(DeleteInstruction command);
        Task<OneOf<InstructionCreated, CreateInstructionFailed>> AddAsyncInstruction(CreateInstruction command);

        Task<OneOf<InstructionUpdated, UpdateInstructionFailed>> UpdateAsyncInstruction(UpdateInstruction command);

        // For Items
        Task<OneOf<ItemCreated, CreateItemFailed>> AddAsyncItem(CreateItem command);

        // For InstructionItems
        Task<OneOf<InstructionItemDeleted, DeleteInstructionItemFailed>> DeleteAsyncInstructionItem(DeleteInstructionItem command);

        Task<OneOf<InstructionItemCreated, CreateInstructionItemFailed>> AddAsyncInstructionItem(CreateInstructionItem command);
    }
}
