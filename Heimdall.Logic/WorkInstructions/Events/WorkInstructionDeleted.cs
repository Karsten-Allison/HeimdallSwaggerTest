using Heimdall.Logic.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heimdall.Logic.WorkInstructions.Events
{
    public record WorkInstructionDeleted(int Id) : IEvent;
}
