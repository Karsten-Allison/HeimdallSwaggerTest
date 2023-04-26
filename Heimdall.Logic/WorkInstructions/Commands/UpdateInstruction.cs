using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Heimdall.Logic.Core;
using Heimdall.Logic.WorkInstructions.Entities;

namespace Heimdall.Logic.WorkInstructions.Commands
{
    /// <summary>
    /// A command object to update a instruction.
    /// </summary>
    /// <param name="InstructionText"></param>
    /// <param name="InstructionImage"></param>
    /// <param name="InstructionCordinates"></param>
    public record UpdateInstruction(int Id, int InstructionID, string? InstructionText, string? InstructionImage, string? InstructionCordinates, List<InstructionItem>? InstructionItems) : ICommand;
}
