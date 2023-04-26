using Heimdall.Logic.Core;
using Heimdall.Logic.WorkInstructions.Commands;
using Heimdall.Logic.WorkInstructions.Events;
using Microsoft.Extensions.Logging;
using OneOf;
using System.Xml.XPath;

namespace Heimdall.Logic.WorkInstructions
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// RLP - By creating a Logic class separate from the accessor class, additional behavior like
    /// checking for any business logic related to limits, data, validation, can be done independent
    /// of the raw logic needed to create, read, update, or delete an entity. I've added an ILogger
    /// here to represent a simple amount of "business logic" that needs to happen outside of the
    /// actual database operation.
    /// </remarks>
    internal class WorkInstructionLogic : IWorkInstructionLogic
    {
        private readonly IWorkInstructionAccessor _accessor;
        private readonly ILogger<WorkInstructionLogic> _logger;

        public WorkInstructionLogic(IWorkInstructionAccessor accessor, ILogger<WorkInstructionLogic> logger)
        {
            _accessor = accessor;
            _logger = logger;
        }

        public async Task<OneOf<WorkInstructionRead, WorkInstructionNotFound>> GetAsync(ReadWorkInstruction query)
        {
            _logger.LogTrace("Query Received: {Query}", query);

            var result = await _accessor.GetAsync(query);

            if (result.TryPickT1(out var failure, out var _))
            {
                // RLP - The {} are structured logging parameters; in the logs,
                // a field will be logged with the name "Id"  and the value from
                // the first parameter after the logging string.
                _logger.LogError("Work instruction with Id {Id} not found", failure.Id);
            }

            return result;
        }

        public async Task<OneOf<WorkInstructionsRead, WorkInstructionNotFound>> GetAllAsync()
        {
            _logger.LogTrace("Query Received: {Query}", "GetAllWorkInstructions");

            var result = await _accessor.GetAllAsync();

            if (result.TryPickT1(out var failure, out var _))
            {
                _logger.LogError("Failed to get work instructions.");
            }

            return result;
        }

        public async Task<OneOf<WorkInstructionCreated, CreateWorkInstructionFailed>> AddAsync(CreateWorkInstruction command)
        {
            _logger.LogTrace("Command Received: {Command}", command);

            var result = await _accessor.AddAsync(command);

            if (result.TryPickT1(out var failure, out var _))
            {
                _logger.LogError("Failed to add item {Command}, got error: {ErrorMessage}", failure.Command, failure.Reason);
            }

            return result;
        }

        public async Task<OneOf<WorkInstructionUpdated, UpdateWorkInstructionFailed>> UpdateAsync(UpdateWorkInstruction command)
        {
            _logger.LogTrace("Command Received: {Command}", command);

            var result = await _accessor.UpdateAsync(command);

            if (result.TryPickT1(out var failure, out var _))
            {
                _logger.LogError("Failed to update item with {Command}, got error: {ErrorMessage}", failure.Command, failure.Reason);
            }

            return result;
        }

        public async Task<OneOf<WorkInstructionDeleted, DeleteWorkInstructionFailed>> DeleteAsync(DeleteWorkInstruction command)
        {
            _logger.LogTrace("Command Received: {Command}", command);

            var result = await _accessor.DeleteAsync(command);

            if (result.TryPickT1(out var failure, out var _))
            {
                _logger.LogError("Failed to delete item {Id}, got error: {ErrorMessage}", failure.Command.Id, failure.Reason);
            }

            return result;
        }

        public async Task<OneOf<InstructionCreated, CreateInstructionFailed>> AddAsyncInstruction(CreateInstruction command)
        {
            _logger.LogTrace("Command Received: {Command}", command);

            var result = await _accessor.AddAsyncInstruction(command);

            if (result.TryPickT1(out var failure, out var _))
            {
                _logger.LogError("Failed to add item {Command}, got error: {ErrorMessage}", failure.Command, failure.Reason);
            }

            return result;
        }

        public async Task<OneOf<InstructionDeleted, DeleteInstructionFailed>> DeleteAsyncInstruction(DeleteInstruction command)
        {
            _logger.LogTrace("Command Received: {Command}", command);

            var result = await _accessor.DeleteAsyncInstruction(command);

            if (result.TryPickT1(out var failure, out var _))
            {
                _logger.LogError("Failed to delete item {Id}, got error: {ErrorMessage}", failure.Command.Id, failure.Reason);
            }

            return result;
        }

        public async Task<OneOf<InstructionUpdated, UpdateInstructionFailed>> UpdateAsyncInstruction(UpdateInstruction command)
        {
            _logger.LogTrace("Command Received: {Command}", command);

            var result = await _accessor.UpdateAsyncInstruction(command);

            if (result.TryPickT1(out var failure, out var _))
            {
                _logger.LogError("Failed to delete item {Id}, got error: {ErrorMessage}", failure.Command.Id, failure.Reason);
            }

            return result;
        }

        public async Task<OneOf<ItemCreated, CreateItemFailed>> AddAsyncItem(CreateItem command)
        {
            _logger.LogTrace("Command Received: {Command}", command);

            var result = await _accessor.AddAsyncItem(command);

            if (result.TryPickT1(out var failure, out var _))
            {
                _logger.LogError("Failed to add item {Command}, got error: {ErrorMessage}", failure.Command, failure.Reason);
            }

            return result;
        }

        public async Task<OneOf<InstructionItemDeleted, DeleteInstructionItemFailed>> DeleteAsyncInstructionItem(DeleteInstructionItem command)
        {
            _logger.LogTrace("Command Received: {Command}", command);

            var result = await _accessor.DeleteAsyncInstructionItem(command);

            if (result.TryPickT1(out var failure, out var _))
            {
                _logger.LogError("Failed to delete item {Id}, Instruction ID: {Id2}, got error: {ErrorMessage}", failure.Command.ItemId, failure.Command.InstructionId, failure.Reason);
            }

            return result;
        }

        public async Task<OneOf<InstructionItemCreated, CreateInstructionItemFailed>> AddAsyncInstructionItem(CreateInstructionItem command)
        {
            _logger.LogTrace("Command Received: {Command}", command);

            var result = await _accessor.AddAsyncInstructionItem(command);

            if (result.TryPickT1(out var failure, out var _))
            {
                _logger.LogError("Failed to add item {Command}, got error: {ErrorMessage}", failure.Command, failure.Reason);
            }

            return result;
        }
    }
}
