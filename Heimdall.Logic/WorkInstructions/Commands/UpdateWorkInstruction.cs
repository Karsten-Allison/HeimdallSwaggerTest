﻿using Heimdall.Logic.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heimdall.Logic.WorkInstructions.Commands
{
    /// <summary>
    /// A command object to update any of a work instruction's attributes.
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="Title"></param>
    /// <param name="Description"></param>
    /// <param name="InstructionObject"></param>
    public record UpdateWorkInstruction(int Id, string? Title, string? Description, string? InstructionObject) : ICommand;
}
