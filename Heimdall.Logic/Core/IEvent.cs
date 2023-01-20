using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heimdall.Logic.Events
{
    /// <summary>
    /// Entities that represent a state change that has occurred should extend an IEvent interface.
    /// Events are always past tense - these objects represent things that have happened in the system.
    /// </summary>
    public interface IEvent
    {
    }
}
