﻿using Heimdall.Logic.Events;
using Heimdall.Logic.WorkInstructions.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heimdall.Logic.WorkInstructions.Events
{
    public record UpdateWorkInstructionFailed(UpdateWorkInstruction Command, string Reason)
        : ICommandFailedEvent<UpdateWorkInstruction>;
}
