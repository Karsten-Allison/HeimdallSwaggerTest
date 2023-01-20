using Heimdall.Logic.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heimdall.Logic.Events
{
    /// <summary>
    /// An event recording that a command failed.
    /// </summary>
    /// <typeparam name="T">The command that failed.</typeparam>
    public interface ICommandFailedEvent<T> : IEvent
        where T : ICommand
    {
        /// <summary>
        /// The original command message.
        /// </summary>
        T Command { get; }

        /// <summary>
        /// Why the command failed.
        /// </summary>
        string Reason { get; }
    }
}
