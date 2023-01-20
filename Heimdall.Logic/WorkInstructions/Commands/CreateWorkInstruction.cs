using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Heimdall.Logic.Core;

namespace Heimdall.Logic.WorkInstructions.Commands
{
    /// <summary>
    /// A command object to create work instruction.
    /// </summary>
    /// <param name="Title"></param>
    /// <param name="Description"></param>
    /// <param name="InstructionObject"></param>
    public record CreateWorkInstruction(string Title, string Description, string InstructionObject) : ICommand;
}
