using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heimdall.Logic.Events
{
    /// <summary>
    /// An event recording that an entity was created.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IEntityCreatedEvent<T> : IEvent
    {
        /// <summary>
        /// The entity created.
        /// </summary>
        T Value { get; }
    }
}
