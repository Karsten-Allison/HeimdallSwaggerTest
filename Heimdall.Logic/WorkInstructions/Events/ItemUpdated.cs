using Heimdall.Logic.Events;
using Heimdall.Logic.WorkInstructions.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heimdall.Logic.WorkInstructions.Events
{
    public record ItemUpdated(Item Value) : IEvent;
}
