using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heimdall.Logic.Events
{
    /// <summary>
    /// A kind of event where an entity was not found.
    /// </summary>
    internal interface IEntityNotFoundEvent : IEvent
    {
        int Id { get; }
    }
}
