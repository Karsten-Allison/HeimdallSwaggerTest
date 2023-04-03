using Heimdall.Logic.Core;
using Heimdall.Logic.WorkInstructions;
using Heimdall.Logic.WorkInstructions.Commands;
using Heimdall.Logic.WorkInstructions.Entities;
using Heimdall.Logic.WorkInstructions.Events;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Query.ExpressionTranslators.Internal;
using OneOf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heimdall.Data.Accessors
{
    internal class WorkInstructionAccessor : IWorkInstructionAccessor
    {
        private readonly WorkInstructionDatabaseContext _context;

        public WorkInstructionAccessor(WorkInstructionDatabaseContext context)
        {
            _context = context;
        }

        public async Task<OneOf<WorkInstructionCreated, CreateWorkInstructionFailed>> AddAsync(CreateWorkInstruction command)
        {
            var workInstruction = new WorkInstruction()
            {
                Title = command.Title,
                Description = command.Description,
                InstructionList = command.InstructionList,
            };
            try
            {
                _context.WorkInstructions.Add(workInstruction);
                await _context.SaveChangesAsync();
                return new WorkInstructionCreated(workInstruction);
            }
            catch (Exception ex)
            {
                return new CreateWorkInstructionFailed(command, ex.Message);
            }
        }

        public async Task<OneOf<InstructionCreated, CreateInstructionFailed>> AddAsyncInstruction(CreateInstruction command)
        {
            var Instruction = new Instruction()
            {
                InstructionText = command.InstructionText,
                InstructionImage = command.InstructionImage,
                InstructionCordinates = command.InstructionCordinates,
                InstructionForeignKey = command.ForeignKeyId
            };
            try
            {
                _context.Instructions.Add(Instruction);
                await _context.SaveChangesAsync();
                return new InstructionCreated(Instruction);
            }
            catch (Exception ex)
            {
                return new CreateInstructionFailed(command, ex.Message);
            }
        }

        public async Task<OneOf<WorkInstructionDeleted, DeleteWorkInstructionFailed>> DeleteAsync(DeleteWorkInstruction command)
        {
            var workInstruction = await _context.WorkInstructions.FindAsync(command.Id);

            if (workInstruction is null)
            {
                return new DeleteWorkInstructionFailed(command, $"Could not find work instruction with id {command.Id}");
            }

            _context.Remove(workInstruction);
            await _context.SaveChangesAsync();

            return new WorkInstructionDeleted(command.Id);
        }

        public async Task<OneOf<InstructionDeleted, DeleteInstructionFailed>> DeleteAsyncInstruction(DeleteInstruction command)
        {
            var workInstruction = await _context.WorkInstructions.FindAsync(command.Id);

            if (workInstruction is null)
            {
                return new DeleteInstructionFailed(command, $"Could not find work instruction with id {command.Id}");
            }

            var Instruction = await _context.Instructions.FindAsync(command.InstructionID);

            if (Instruction is null)
            {
                return new DeleteInstructionFailed(command, $"Could not find instruction with id {command.InstructionID}");
            }

            _context.Remove(Instruction);
            await _context.SaveChangesAsync();

            return new InstructionDeleted(command.InstructionID);
        }

        public async Task<OneOf<WorkInstructionsRead, WorkInstructionNotFound>> GetAllAsync()
        {
            WorkInstruction[] databaseInstructions = (await _context.WorkInstructions
                .Include(workinstruction => workinstruction.InstructionList).ToArrayAsync()) ?? Array.Empty<WorkInstruction>();
            
            return new WorkInstructionsRead(databaseInstructions);
        }

        public async Task<OneOf<WorkInstructionRead, WorkInstructionNotFound>> GetAsync(ReadWorkInstruction command)
        {
            WorkInstruction? workInstruction = await _context.WorkInstructions
                .Include(workinstruction => workinstruction.InstructionList)
                .FirstOrDefaultAsync(workinstruction => workinstruction.Id == command.Id);

            if (workInstruction is null)
            {
                return new WorkInstructionNotFound(command.Id);
            }

            return new WorkInstructionRead(workInstruction);
        }

        public async Task<OneOf<WorkInstructionUpdated, UpdateWorkInstructionFailed>> UpdateAsync(UpdateWorkInstruction command)
        {

            var workInSet = await _context.WorkInstructions.FindAsync(command.Id);

            // RLP - Fail early. Find bad cases, return, and continue with good cases.
            if (workInSet is null)
            {
                return new UpdateWorkInstructionFailed(command, $"Unable to find Work Instruction with id {command.Id}");
            }

            if (command.Title is not null)
            {
                workInSet.Title = command.Title;
            }
            if (command.Description is not null)
            {
                workInSet.Description = command.Description;
            }
            if (command.InstructionList is not null)
            {
                workInSet.InstructionList = command.InstructionList;
            }

            await _context.SaveChangesAsync();

            return new WorkInstructionUpdated(workInSet);
        }

        public async Task<OneOf<InstructionUpdated, UpdateInstructionFailed>> UpdateAsyncInstruction(UpdateInstruction command)
        {
            var workInstruction = await _context.WorkInstructions.FindAsync(command.Id);

            if (workInstruction is null)
            {
                return new UpdateInstructionFailed(command, $"Could not find work instruction with id {command.Id}");
            }

            var Instruction = await _context.Instructions.FindAsync(command.InstructionID);

            if (Instruction is null)
            {
                return new UpdateInstructionFailed(command, $"Could not find instruction with id {command.InstructionID}");
            }

            if(command.InstructionText is not null)
            {
                Instruction.InstructionText = command.InstructionText;
            }
            if(command.InstructionImage is not null)
            {
                Instruction.InstructionImage = command.InstructionImage;
            }
            if(command.InstructionCordinates is not null)
            {
                Instruction.InstructionCordinates = command.InstructionCordinates;
            }


            await _context.SaveChangesAsync();

            return new InstructionUpdated(Instruction);
        }

    }
}
