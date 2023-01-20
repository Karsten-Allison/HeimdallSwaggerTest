using Heimdall.Logic.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heimdall.Logic.WorkInstructions.Commands
{
    public record DeleteWorkInstruction(int Id) : ICommand;
}
